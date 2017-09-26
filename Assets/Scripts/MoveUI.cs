using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour
{
    int speed = 3;

    Vector3 main_menu_position;
    Vector3 select_video_position;
    Vector3 store_position;
    Vector3 settings_position;
    Vector3 about_position;

    static public bool main_menu;
    static public bool select_video;
    static public bool store;
    static public bool settings;
    static public bool about;

    void Start ()
    {
        main_menu_position = new Vector3(0, 0, 0);
        select_video_position = new Vector3(-1500*Initilize.mobile_ui_scale_factor, 0, 0);
        store_position = new Vector3(1500*Initilize.mobile_ui_scale_factor, 0, 0);
        settings_position = new Vector3(0, -1000*Initilize.mobile_ui_scale_factor, 0);
        about_position = new Vector3(0, 1000*Initilize.mobile_ui_scale_factor, 0);
        transform.localPosition = main_menu_position;

        transform.localScale = new Vector3(Initilize.mobile_ui_scale_factor, Initilize.mobile_ui_scale_factor, Initilize.mobile_ui_scale_factor);

        main_menu = true;
        select_video = false;
        store = false;
        settings = false;
        about = false;
    }
	
	void Update ()
    {
		if (main_menu)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, main_menu_position, Time.deltaTime * speed);
        }
        else if (select_video)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, select_video_position, Time.deltaTime * speed);
        }
        else if (store)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, store_position, Time.deltaTime * speed);
        }
        else if (settings)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, settings_position, Time.deltaTime * speed);
        }
        else if (about)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, about_position, Time.deltaTime * speed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, main_menu_position, Time.deltaTime * speed);
        }
    }
}
