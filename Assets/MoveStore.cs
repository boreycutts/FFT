using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStore : MonoBehaviour
{
    static public bool ship = true;
    static public bool color = false;

    Vector3 ship_position = new Vector3(0, 0, 0);
    Vector3 color_position = new Vector3(0, -110, 0);
	void Start ()
    {
		
	}

	void Update ()
    {
		if (ship)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, ship_position, Time.deltaTime * 2);
        }
        else if (color)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, color_position, Time.deltaTime * 2);
        }
	}
}
