using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    Vector3 health_scale;
    Vector3 new_scale;
	void Start ()
    {
        /*health_scale = transform.localScale;
        health_scale.x = 0.00025f *RotatePlayer.score;
        transform.localScale = health_scale;*/
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*health_scale = transform.localScale;
        new_scale = health_scale;
        new_scale.x = 0.00025f * RotatePlayer.score;
        transform.localScale = Vector3.Lerp(health_scale, new_scale, Time.deltaTime);
        */
    }
}
