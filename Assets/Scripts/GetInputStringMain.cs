using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputStringMain : MonoBehaviour
{
    static public string main_input_string;
	void Start () {
		
	} 

	void Update ()
    {
        main_input_string = gameObject.GetComponent<InputField>().text;
    }
}
