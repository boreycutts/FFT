using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    Color original_color = new Color();
    Color light_color = new Color();
    Color new_color = new Color();

    void Start ()
    {
        original_color = new Color(0.8f, 0.8f, 0.8f);
        gameObject.GetComponent<Light>().color = original_color;
	}

	void Update ()
    {
        light_color = gameObject.GetComponent<Light>().color;
        new_color = light_color;
        new_color.r = original_color.r + original_color.r * BuildGround.average * 50;
        new_color.b = original_color.b + original_color.b * BuildGround.average * 50;
        gameObject.GetComponent<Light>().color = Color.Lerp(light_color, new_color, Time.deltaTime * 200);//Mathf.PingPong(Time.time, 4) / 4);
    }
}
