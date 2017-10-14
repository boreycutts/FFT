using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullets_SmallBoss_Ring : MonoBehaviour
{
    int spawn_probabilty = 150; // Sets the probability that bullets will spawn due to music intensity
    float intensity_count = 0; // Increases based on music's bass intensity
    int count = 0;
    public GameObject bullet_ring_prefab;

    void Start ()
    {

	}
	
	void Update ()
    {
        intensity_count += BuildGround.average_low * 100;

        if (intensity_count > spawn_probabilty)
        {
            Instantiate(bullet_ring_prefab, MoveEnemy_SmallBoss.position, transform.localRotation);
            intensity_count = 0;
        }
    }
}
