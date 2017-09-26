using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateEnemyHealth : MonoBehaviour
{
    void Start()
    {

    }

	void Update ()
    {
        transform.localScale = new Vector3(MoveEnemy_SmallBoss.health/500, 0.02f, 0.02f);
	}
}
