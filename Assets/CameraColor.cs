using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    int color_1_temp;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (PlayerColor.color1 != color_1_temp)
        {
            if (PlayerColor.color1 == 0)
            {
                GetComponent<Camera>().backgroundColor = new Color(1, 0.5f, 0.5f);
            }
            else if (PlayerColor.color1 == 1)
            {
                GetComponent<Camera>().backgroundColor = new Color(1, 0.75f, 0.5f);
            }
            else if (PlayerColor.color1 == 2)
            {
                GetComponent<Camera>().backgroundColor = new Color(1, 1, 0.5f);
            }
            else if (PlayerColor.color1 == 3)
            {
                GetComponent<Camera>().backgroundColor = new Color(0.5f, 1, 0.5f);
            }
            else if (PlayerColor.color1 == 4)
            {
                GetComponent<Camera>().backgroundColor = new Color(0.5f, 0.5f, 1);
            }
            else if (PlayerColor.color1 == 5)
            {
                GetComponent<Camera>().backgroundColor = new Color(0.75f, 0.5f, 1);
            }
            else if (PlayerColor.color1 == 6)
            {
                GetComponent<Camera>().backgroundColor = new Color(1, 0.5f, 1);
            }
            else if (PlayerColor.color1 == 7)
            {
                GetComponent<Camera>().backgroundColor = new Color(0.95f, 0.95f, 0.95f);
            }
            else if (PlayerColor.color1 == 8)
            {
                GetComponent<Camera>().backgroundColor = new Color(0.75f, 0.75f, 0.75f);
            }
            else if (PlayerColor.color1 == 9)
            {
                GetComponent<Camera>().backgroundColor = new Color(0.5f, 0.5f, 0.5f);
            }
            else if (PlayerColor.color1 == 10)
            {
                GetComponent<Camera>().backgroundColor = new Color(0.25f, 0.25f, 0.25f);
            }
        }

        color_1_temp = PlayerColor.color1;
    }
}
