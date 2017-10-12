using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyBullet : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

        transform.Translate(0, 0.5f, -4);
        if (AddBullets_SmallBoss.is_shooting)
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
	}
}
