using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Explosion_SmallBoss : MonoBehaviour
{
    int count = 0;
    void Start()
    {

    }

    void Update()
    {
        count++;
        if (count > 60 * 10)
        {
            Destroy(this.gameObject);
        }
    }
}