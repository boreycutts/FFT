using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    

    void Start ()
    {
        
    }

	void Update ()
    {
        if (transform.localPosition.z < 500)
        {
            transform.Translate(0, -1, 6);
        }
        else
        {
            transform.Translate(0, 0, 0);
        }
	}
}
