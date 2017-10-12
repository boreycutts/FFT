using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullets_SmallBoss : MonoBehaviour
{
    int spawn_probabilty = 70; // Sets the probability that bullets will spawn due to music intensity
    float intensity_count = 0; // Increases based on music's bass intensity
    static public bool is_shooting = false;

	void Start ()
    {
        transform.localPosition = new Vector3(156, 81, -16);//MoveEnemy_SmallBoss.position;
	}
	
	void Update ()
    {
        intensity_count += 1; //ENABLE THIS TO WORK WITH MUSIC: BuildGround.average_low * 100;

        if (intensity_count > spawn_probabilty)
        {
            transform.localPosition = MoveEnemy_SmallBoss.position;
            is_shooting = true;
            intensity_count = 0;
        }
        else
        {
            is_shooting = false;
        }
	}
}
