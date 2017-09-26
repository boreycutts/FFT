using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputString : MonoBehaviour
{
    static public string input_string;

	void Start ()
    {
		
	}

	void Update ()
    {
        input_string = gameObject.GetComponent<InputField>().text;
	}
}
