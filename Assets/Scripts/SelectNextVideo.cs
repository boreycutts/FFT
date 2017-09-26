using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNextVideo : MonoBehaviour
{
    static public bool video_chosen = false;
    static public bool play_video = false;

    Vector3 side_position = new Vector3(2000, 0, 0);
    Vector3 middle_position = new Vector3(0, 0, 0);
    Vector3 current_position;
    // Use this for initialization
    void Start ()
    {
        transform.localPosition = side_position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        current_position = transform.localPosition;

        if (GameOver.keep_going)
        {
            transform.localPosition = Vector3.Lerp(current_position, middle_position, Time.deltaTime * 2);
        }

        if (video_chosen)
        {
            transform.localPosition = Vector3.Lerp(current_position, side_position, Time.deltaTime * 2);
        }

        if (transform.localPosition.x >= side_position.x - 1 && video_chosen)
        {
            play_video = true;
            
        }
    }
}
