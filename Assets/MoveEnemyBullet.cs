using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyBullet : MonoBehaviour
{
    static public bool reset_position = false;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0, 0.25f, -2);
	}
}
