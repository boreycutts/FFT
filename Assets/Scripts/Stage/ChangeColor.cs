using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Color original_color = new Color();
    Color background_color = new Color();
    Color new_color = new Color();
    MeshRenderer background_renderer; 

    void Start ()
    {
		background_renderer = gameObject.GetComponent<MeshRenderer>();
        background_renderer.material.color = new Color(0.2f, 0.2f, 0.4f);
    }

	void Update ()
    {
        background_color = background_renderer.material.color;
        new_color = background_color;
        new_color.r = original_color.r * BuildGround.average * 100;
        background_renderer.material.color = Color.Lerp(background_color, new_color, Mathf.PingPong(Time.time, 4f) / 4f);
    }
}
