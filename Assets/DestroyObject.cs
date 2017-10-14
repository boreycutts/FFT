using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    int count = 0;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        count++;
        if (count > 120)
        {
            Destroy(this.gameObject);
        }
	}
}
