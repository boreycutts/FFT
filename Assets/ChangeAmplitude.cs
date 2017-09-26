using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAmplitude : MonoBehaviour
{
    int x;

	void Start ()
    {
		
	}
	void Update ()
    {

        if (int.TryParse(GetComponent<InputField>().text, out x) && x > 0)
        {
            Initilize.cave_intensity = Int32.Parse(GetComponent<InputField>().text) * 600 / 5;
        }
        else
        {
            Initilize.cave_intensity = 1;
        }
	}
}
