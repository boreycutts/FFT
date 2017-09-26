using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    //static public bool video_chosen = false;
    static public bool keep_going = false;
    static public bool main_menu = false;

    Vector3 top_position = new Vector3(0, 1000, 0);
    Vector3 bottom_position = new Vector3 (0, 0, 0);
    Vector3 current_position;
	// Use this for initialization
	void Start ()
    {
        transform.localPosition = top_position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        current_position = transform.localPosition;
		if (SimplePlayback.video_played)
        {
            transform.localPosition = Vector3.Lerp(current_position, bottom_position, Time.deltaTime);
        }
        
        if (keep_going)
        {
            transform.localPosition = Vector3.Lerp(current_position, top_position, Time.deltaTime);
        }
        else if (main_menu)
        {

        }
	}
}
