using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoinScore : MonoBehaviour
{
    static public int count = 0;

    Vector3 score_position;

    void Start ()
    {
        
	}
	
	void Update ()
    {
        score_position = transform.localPosition;
        if (count < 500)
        {
            count++;
            transform.Translate(0, 0.35f, 0);
            //GetComponent<Renderer>
        }
        else
        {
            score_position = new Vector3(0, 0, -50);
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, score_position, Time.deltaTime);
	}
}
