using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundColor : MonoBehaviour
{
    Color original_color = new Color();
    Color background_color = new Color();
    Color new_color = new Color();
    MeshRenderer background_renderer;

    void Start ()
    {
        original_color = new Color(0.2f, 0.2f, 0.4f); // Camera.main.backgroundColor;
       
    }
	
	void Update ()
    {
        background_color = Camera.main.backgroundColor;
        new_color = background_color;
        new_color.r = original_color.r * BuildGround.average * 100;
        Camera.main.backgroundColor = Color.Lerp(background_color, new_color, Mathf.PingPong(Time.time, 4f) / 4f);
    }
}
