using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy_SmallBoss : MonoBehaviour
{
    static public bool is_alive = false;

    int count;
    static public float health = 200;

    Vector3 target_position = new Vector3();
    static public Vector3 position = new Vector3();

    public GameObject explosion;
    public GameObject explosion_small;

    void Start ()
    {
        is_alive = true;
        position = transform.localPosition;
    }
	void Update ()
    {
        transform.localScale = new Vector3(50 + BuildGround.average * 500, 50 + BuildGround.average * 500, 50);
        position = transform.localPosition;
        if (is_alive)
        {
            target_position = MovePlayer.player_position;
            target_position.z = -20;
            target_position.y = MovePlayer.player_position.y - 40;
            transform.localPosition = Vector3.Lerp(transform.localPosition, target_position, Time.deltaTime * 0.5f);
        }
        else
        {
            transform.localPosition = new Vector3(0, 0, -500);
            count++;

            if (count > 60 * 50)
            {
                count = 0;
                is_alive = true;
            }
            else
            {
                count++;
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Bullet")
        {
            if (health < 0)
            {
                PlayerScore.score += 200;
                health = 200;
                is_alive = false;
                Instantiate(explosion, transform.position, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                health--;
                Instantiate(explosion_small, transform.position, new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
