using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using YoutubeLight;

public class HighQualityPlayback : MonoBehaviour {
	private System.Threading.Thread m_Thread = null;
    string videoId = GetInputString.input_string;

    public VideoQuality videoQuality;
	private string videoUrl;
	private string audioVideoUrl;
	private bool videoAreReadyToPlay = false;
	//use unity player(all platforms) or old method to play in mobile only if you want, or if your mobile dont support the new player.
	public bool useNewUnityPlayer;
	//If you will use high quality playback we need one video player that only will run the audio.
	public VideoPlayer unityVideoPlayer;
	//start playing the video
	public bool playOnStart = false;

	public bool noHD = false;

    bool video_played = false;
    static public bool game_over = false;

	public void Awake(){

        if (Application.isMobilePlatform)
        {
            if (GetMaxQualitySupportedByDevice() <= 720)
            {
                //low end device..
                if(videoQuality != VideoQuality.mediumQuality)
                    videoQuality = VideoQuality.Hd720;
                noHD = true;
            }
        }

        if (playOnStart) {
			#if UNITY_WEBGL
				GetTheVideo();
			#else
				PlayYoutubeVideo(videoId);
			#endif
                
		}
	}


    public void PlayYoutubeVideo(string _videoId)
	{
        if(this.GetComponent<VideoController>() != null)
        {
            this.GetComponent<VideoController>().ShowLoading("Loading...");
        }
		videoId = _videoId;
        //Call the video system in another thread
        m_Thread = new System.Threading.Thread(GetTheVideo);
		m_Thread.Start();
        //GetTheVideo();
	}

	//this will run only in another thread.
	void GetTheVideo()
	{
		List<VideoInfo> videoInfos = RequestResolver.GetDownloadUrls(videoId, false);

		//Get the video with audio first
		foreach (VideoInfo info in videoInfos)
		{
			
			if (info.VideoType == VideoType.Mp4 && info.Resolution ==(360)) {
				if (info.RequiresDecryption) {
					//The string is the video url with audio
					audioVideoUrl = RequestResolver.DecryptDownloadUrl (info);
				} else {
					audioVideoUrl = info.DownloadUrl;
				}
				break;
			}
		}

		int quality = 360;
		switch (videoQuality) {
		case VideoQuality.mediumQuality:
			quality = 360;
			break;
		case VideoQuality.Hd720:
			quality = 720;
			break;
		case VideoQuality.Hd1080:
			quality = 1080;
			break;
		case VideoQuality.Hd1440:
			quality = 1440;
			break;
		case VideoQuality.Hd2160:
			quality = 2160;
			break;
		}

		bool foundVideo = false;
		//Get the high quality video
		foreach (VideoInfo info in videoInfos) 
		{
			if (info.VideoType == VideoType.Mp4 && info.Resolution ==(quality)) {
				if (info.RequiresDecryption) {
					//The string is the video url
					videoUrl = RequestResolver.DecryptDownloadUrl (info);
				} else {
					videoUrl = info.DownloadUrl;
				}
				foundVideo = true;
				videoAreReadyToPlay = true;
				break;
			}
		}
		//if desired quality not found try another lower quality.
		if (!foundVideo) {
			Debug.Log ("Desired quality not found, playing with low quality, check if the video id: "+videoId+" support that quality!");
			foreach (VideoInfo info in videoInfos) 
			{
				if (info.VideoType == VideoType.Mp4 && info.Resolution ==(360)) {
					if (info.RequiresDecryption) {
						//The string is the video url
						videoUrl = RequestResolver.DecryptDownloadUrl (info);
					} else {
						videoUrl = info.DownloadUrl;
					}
					videoAreReadyToPlay = true;
					break;
				}
			}
		}
	}

    public VideoPlayer audioVplayer;
	bool checkIfVideoArePrepared = false;

	void FixedUpdate(){
		//used this to play in main thread.
		if (videoAreReadyToPlay) {
			videoAreReadyToPlay = false;
			//play using the old method
			if (!useNewUnityPlayer)
				StartCoroutine (StartVideo ());
			else {
				Debug.Log ("Play!!" + videoUrl);
				unityVideoPlayer.source = VideoSource.Url;
				unityVideoPlayer.url = videoUrl;
				checkIfVideoArePrepared = true;
				unityVideoPlayer.Prepare ();
				if (!noHD) {
					audioVplayer.source = VideoSource.Url;
					audioVplayer.url = audioVideoUrl;
					audioVplayer.Prepare ();
				}
			}
		}

		if (checkIfVideoArePrepared) {
			checkIfVideoArePrepared = false;
			videoPrepared = false;
			unityVideoPlayer.prepareCompleted += VideoPrepared;
			if(!noHD) {
				audioPrepared = false;
				audioVplayer.prepareCompleted += AudioPrepared;
			}


		}
        CheckIfIsDesync();

        // MY EDIT
        if (video_played)
        {
            if (SelectNextVideo.video_chosen)
            {
                PlayYoutubeVideo(GetInputString.input_string);
                video_played = false;
                game_over = false;
                SelectNextVideo.video_chosen = false;
            }
        }
    }

	private bool videoPrepared;
	private bool audioPrepared;

	void AudioPrepared(VideoPlayer vPlayer){
        audioVplayer.prepareCompleted -= AudioPrepared;
        audioPrepared = true;
        if (audioPrepared && videoPrepared)
			Play ();
	}

	void VideoPrepared(VideoPlayer vPlayer){
        unityVideoPlayer.prepareCompleted -= VideoPrepared;
        videoPrepared = true;
		if (noHD) {
            Play();
        } else {
			if (audioPrepared && videoPrepared)
				Play ();
		}

	}

	public void Play(){
		unityVideoPlayer.loopPointReached += PlaybackDone;
    	StartCoroutine(WaitAndPlay());
	}

	private void PlaybackDone(VideoPlayer vPlayer){
		OnVideoFinished ();
	}

    IEnumerator WaitAndPlay()
    {

        if (!noHD)
        {
            audioVplayer.Play();
            yield return new WaitForSeconds(0.35f);
        }
        else
            yield return new WaitForSeconds(1f);//if is no hd wait some more
        unityVideoPlayer.Play();
        if (this.GetComponent<VideoController>() != null)
        {
            this.GetComponent<VideoController>().HideLoading();
        }
    }

	IEnumerator StartVideo(){
		#if UNITY_IPHONE || UNITY_ANDROID
		Handheld.PlayFullScreenMovie (videoUrl);
		#endif
		yield return new WaitForSeconds (1.4f);
		OnVideoFinished ();
	}

	public void OnVideoFinished(){
		if (unityVideoPlayer.isPrepared) {
			Debug.Log ("Finished");
			if (unityVideoPlayer.isLooping)
			{
				unityVideoPlayer.time = 0;
				unityVideoPlayer.frame = 0;
				audioVplayer.time = 0;
				audioVplayer.frame = 0;
				unityVideoPlayer.Play();
				audioVplayer.Play();
			}

            video_played = true;
            game_over = true;
        }
	}

    public enum VideoQuality{
		mediumQuality,
		Hd720,
		Hd1080,
		Hd1440,
		Hd2160
	}

    public bool isSyncing = false;

    //Experimental
    private void CheckIfIsDesync(){
        if (!noHD)
        {
            //Debug.Log(unityVideoPlayer.time+" "+ audioVplayer.time);
            double t = unityVideoPlayer.time - audioVplayer.time;
            if (!isSyncing)
            {
                if (t != 0)
                {
                    Sync();
                }
                else if (unityVideoPlayer.frame != audioVplayer.frame)
                {
                    Sync();
                }
            }
        }
        else
        {
            //unityVideoPlayer.frame -= 1;
        }
    }

    private void Sync()
    {
        VideoController controller = GameObject.FindObjectOfType<VideoController>();
        if(controller != null)
        {
            //isSyncing = true;
            //audioVplayer.time = unityVideoPlayer.time;
            //audioVplayer.frame = unityVideoPlayer.frame;
            //controller.Seek();
        }
        else
        {
            Debug.LogWarning("Please add a video controller to your scene to make the sync work! Will be improved in the future.");
        }
    }

    public int GetMaxQualitySupportedByDevice()
    {
        if (Screen.orientation == ScreenOrientation.Landscape)
        {
            //use the height
            return Screen.currentResolution.height;
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
        {
            //use the width
            return Screen.currentResolution.width;
        }
        else
        {
            return Screen.currentResolution.height;
        }
    }

    private void onGameOver()
    {
        PlayYoutubeVideo("3Z1h2VE0hzs");
    }
}
