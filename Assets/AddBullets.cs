using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullets : MonoBehaviour
{
    int count = 0;
    int bullet_index = 0;
    GameObject[] bullet_array;

	void Start ()
    {
        bullet_array = GameObject.FindGameObjectsWithTag("EnemyBullet_SmallBoss");
	}

	void Update ()
    {
        Debug.Log(bullet_array.Length);
		if (count > 10)
        {
            if (bullet_index < bullet_array.Length)
            {
                bullet_array[bullet_index].transform.localPosition = MoveEnemy_SmallBoss.position;
                bullet_index++;
            }
            else
            {
                bullet_index = 0;
            }
            count = 0;
        }
        else
        {
            count++;
        }
	}
}
