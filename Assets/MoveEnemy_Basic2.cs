using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy_Basic2 : MonoBehaviour
{
    static public bool is_alive2 = false;

    int count = 0;

    Quaternion original_rotation;

    Vector3 target_position;
    void Start()
    {
        original_rotation = transform.localRotation;
        is_alive2 = true; // ADD FUNCTIONALITY TO ENNEMY CONTROLLER
    }

    void Update()
    {
        if (is_alive2)
        {
            target_position = MovePlayer.player_position;
            target_position.z = -200;
            target_position.x = MovePlayer.player_position.x - 5;
            target_position.y = MovePlayer.player_position.y - 5;
            transform.localPosition = Vector3.Lerp(transform.localPosition, target_position, Time.deltaTime * 4);
            if (transform.localPosition.x > MovePlayer.player_position.x + 10)
            {
                transform.Rotate(0, 9, 0);
            }
            else if (transform.localPosition.x < MovePlayer.player_position.x - 10)
            {
                transform.Rotate(0, -9, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, original_rotation, Time.deltaTime * 4);
            }
        }
        
        else
        {
            transform.localPosition = new Vector3(0, 0, -500);

            if (count > 60 * 4)
            {
                is_alive2 = true;
                count = 0;
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
            PlayerScore.score += 10;
            is_alive2 = false;
        }
    }
}
