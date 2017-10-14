using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEnemyHealth : MonoBehaviour
{
    float health_initial;
    void Start()
    {
        health_initial = MoveEnemy_SmallBoss.health;
    }

	void Update ()
    {
        transform.localScale = new Vector3(MoveEnemy_SmallBoss.health/health_initial, 0.02f, 0.02f);
	}
}
