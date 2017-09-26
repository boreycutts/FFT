using UnityEngine;
using System.Collections;
using CnControls;

public class MovePlayer : MonoBehaviour
{
    Vector3 original_position = new Vector3();
    static public Vector3 player_position;
    Vector3 new_position = new Vector3();
    Quaternion original_rotation = new Quaternion();
    Quaternion player_rotation = new Quaternion();
    Quaternion new_rotation = new Quaternion();

    float vertical_speed = 0;
    float horizontal_speed = 0;
    float max_speed = Initilize.player_max_speed;
    float acceleration = Initilize.player_acceleration;
    float deceleration = Initilize.player_deceleration;
    float speed_deadzone = 1;


    void Start()
    {
        original_rotation = transform.localRotation;
        //transform.localPosition = new Vector3(110, Initilize.cave_depth + 40, Initilize.cave_depth - 220); Supposed to change the positiof of player relative to cave depth. Fix eventually 
    }

    void Update()
    {
        if (Initilize.is_mobile)
        {
            player_position = transform.localPosition;
            new_position = transform.localPosition;

            player_rotation = transform.localRotation;
            new_rotation = player_rotation;

            if (CnControls.CnInputManager.GetAxis("LeftVertical") > 0.4f && vertical_speed > -max_speed && player_position.y < Initilize.cave_height + 35)
            {
                vertical_speed -= acceleration/1 * Time.deltaTime * CnControls.CnInputManager.GetAxis("LeftVertical");
            }
            else if (CnControls.CnInputManager.GetAxis("LeftVertical") < -0.4f && vertical_speed < max_speed && player_position.y > 38)
            {
                vertical_speed += acceleration/1 * Time.deltaTime * -CnControls.CnInputManager.GetAxis("LeftVertical");
            }
            else
            {
                if (vertical_speed > speed_deadzone)
                {
                    vertical_speed -= deceleration * Time.deltaTime;
                }
                else if (vertical_speed < -speed_deadzone)
                {
                    vertical_speed += deceleration * Time.deltaTime;
                }
                else
                {
                    vertical_speed = 0;
                }
            }

            if (CnControls.CnInputManager.GetAxis("LeftHorizontal") > 0.4f && horizontal_speed < max_speed && player_position.x < Initilize.cave_width * Initilize.number_of_blocks / 2 - 15)
            {
                horizontal_speed += acceleration * Time.deltaTime * System.Math.Abs(CnControls.CnInputManager.GetAxis("LeftHorizontal"));
            }
            else if (CnControls.CnInputManager.GetAxis("LeftHorizontal") < -0.4f && horizontal_speed > -max_speed && player_position.x > - 15)
            {
                horizontal_speed -= acceleration * Time.deltaTime * System.Math.Abs(CnControls.CnInputManager.GetAxis("LeftHorizontal"));
            }
            else
            {
                if (horizontal_speed > speed_deadzone)
                {
                    horizontal_speed -= deceleration * Time.deltaTime;
                }
                else if (horizontal_speed < -speed_deadzone)
                {
                    horizontal_speed += deceleration * Time.deltaTime;
                }
                else
                {
                    horizontal_speed = 0;
                }
            }

            if (player_position.x > Initilize.cave_width * Initilize.number_of_blocks / 2 - 15)
            {
                horizontal_speed -= deceleration * 16 * Time.deltaTime;
                PlayerScore.score -= 1;
            }
            else if (player_position.x < - 15)
            {
                horizontal_speed += deceleration * 16 * Time.deltaTime;
                PlayerScore.score -= 1;
            }

            if (player_position.y > Initilize.cave_height + 35)
            {
                vertical_speed += deceleration * 32 * Time.deltaTime;
                PlayerScore.score -= 1;
            }
            else if (player_position.y < 38)
            {
                vertical_speed -= deceleration * 32 * Time.deltaTime;
                PlayerScore.score -= 1;
            }

            new_position.y -= vertical_speed * 0.4f * 2;
            new_position.x += horizontal_speed * 0.6f * 2;

            transform.localPosition = Vector3.Lerp(player_position, new_position, Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(player_rotation, new_rotation, Time.deltaTime * 4);
            // TILT CONTROLS
            /* player_position = transform.localPosition;
             new_position = transform.localPosition;

             player_rotation = transform.localRotation;
             new_rotation = player_rotation;

             if (Input.acceleration.z < -0.8f - Initilize.controller_deadzone && vertical_speed < max_speed && player_position.y < Initilize.cave_height + 35)
             {
                 vertical_speed += acceleration * Time.deltaTime * (Mathf.Abs(Input.acceleration.z));
             }
             else if (Input.acceleration.z > -0.8f + Initilize.controller_deadzone && vertical_speed > -max_speed && player_position.y > 38)
             {
                 vertical_speed -= acceleration * Time.deltaTime * (Mathf.Abs(Input.acceleration.z));
             }
             else
             {
                 if (vertical_speed > speed_deadzone)
                 {
                     vertical_speed -= deceleration * Time.deltaTime;
                 }
                 else if (vertical_speed < -speed_deadzone)
                 {
                     vertical_speed += deceleration * Time.deltaTime;
                 }
                 else
                 {
                     vertical_speed = 0;
                 }
             }

             if (Input.acceleration.x > Initilize.controller_deadzone && horizontal_speed < max_speed && player_position.x < Initilize.cave_width * 32)
             {
                 horizontal_speed += acceleration * Time.deltaTime * System.Math.Abs(Input.acceleration.x);
             }
             else if (Input.acceleration.x < -Initilize.controller_deadzone && horizontal_speed > -max_speed && player_position.x > 5)
             {
                 horizontal_speed -= acceleration * Time.deltaTime * System.Math.Abs(Input.acceleration.x);
             }
             else
             {
                 if (horizontal_speed > speed_deadzone)
                 {
                     horizontal_speed -= deceleration * Time.deltaTime;
                 }
                 else if (horizontal_speed < -speed_deadzone)
                 {
                     horizontal_speed += deceleration * Time.deltaTime;
                 }
                 else
                 {
                     horizontal_speed = 0;
                 }
             }

             if (player_position.x > Initilize.cave_width * 32)
             {
                 horizontal_speed -= deceleration * 4 * Time.deltaTime;
                 PlayerScore.score -= 1;
             }
             else if (player_position.x < 2)
             {
                 horizontal_speed += deceleration * 4 * Time.deltaTime;
                 PlayerScore.score -= 1;
             }

             if (player_position.y > Initilize.cave_height + 35)
             {
                 vertical_speed += deceleration * 16 * Time.deltaTime;
                 PlayerScore.score -= 1;
             }
             else if (player_position.y < 38)
             {
                 vertical_speed -= deceleration * 16 * Time.deltaTime;
                 PlayerScore.score -= 1;
             }

             new_position.y -= vertical_speed * 0.4f * 2;
             new_position.x += horizontal_speed * 0.6f * 2;

             transform.localPosition = Vector3.Lerp(player_position, new_position, Time.deltaTime);*/
        }
        else
        {
            player_position = transform.localPosition;
            new_position = transform.localPosition;

            player_rotation = transform.localRotation;
            new_rotation = player_rotation;

            if (Input.GetAxis("LeftVertical") > 0.4f && vertical_speed < max_speed && player_position.y < Initilize.cave_height + 35)
            {
                vertical_speed += acceleration * Time.deltaTime * Input.GetAxis("LeftVertical");
            }
            else if (Input.GetAxis("LeftVertical") < -0.4f && vertical_speed > -max_speed && player_position.y > 38)
            {
                vertical_speed -= acceleration * Time.deltaTime * -Input.GetAxis("LeftVertical");
            }
            else
            {
                if (vertical_speed > speed_deadzone)
                {
                    vertical_speed -= deceleration * Time.deltaTime;
                }
                else if (vertical_speed < -speed_deadzone)
                {
                    vertical_speed += deceleration * Time.deltaTime;
                }
                else
                {
                    vertical_speed = 0;
                }
            }

            if (Input.GetAxis("LeftHorizontal") > 0.4f && horizontal_speed < max_speed && player_position.x < Initilize.cave_width * Initilize.number_of_blocks/2 - 15)
            {
                horizontal_speed += acceleration * Time.deltaTime * System.Math.Abs(Input.GetAxis("LeftHorizontal"));
            }
            else if (Input.GetAxis("LeftHorizontal") < -0.4f && horizontal_speed > -max_speed && player_position.x > - 15)
            {
                horizontal_speed -= acceleration * Time.deltaTime * System.Math.Abs(Input.GetAxis("LeftHorizontal"));
            }
            else
            {
                if (horizontal_speed > speed_deadzone)
                {
                    horizontal_speed -= deceleration * Time.deltaTime;
                }
                else if (horizontal_speed < -speed_deadzone)
                {
                    horizontal_speed += deceleration * Time.deltaTime;
                }
                else
                {
                    horizontal_speed = 0;
                }
            }

            if (player_position.x > Initilize.cave_width * Initilize.number_of_blocks / 2 - 15)
            {
                horizontal_speed -= deceleration * 4 * Time.deltaTime;
                PlayerScore.score -= 1;
            }
            else if (player_position.x < - 15)
            {
                horizontal_speed += deceleration * 4 * Time.deltaTime;
                PlayerScore.score -= 1;
            }

            if (player_position.y > Initilize.cave_height + 35)
            {
                vertical_speed += deceleration * 16 * Time.deltaTime;
                PlayerScore.score -= 1;
            }
            else if (player_position.y < 38)
            {
                vertical_speed -= deceleration * 16 * Time.deltaTime;
                PlayerScore.score -= 1;
            }

            new_position.y -= vertical_speed * 0.4f * 2;
            new_position.x += horizontal_speed * 0.6f * 2;

            transform.localPosition = Vector3.Lerp(player_position, new_position, Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(player_rotation, new_rotation, Time.deltaTime * 4);
        }
    }
}

// MOBILE CONTROLS // 
/* UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    Vector3 original_position = new Vector3();
    static public Vector3 player_position;
    Vector3 new_position = new Vector3();
    Quaternion original_rotation = new Quaternion();
    Quaternion player_rotation = new Quaternion();
    Quaternion new_rotation = new Quaternion();

    float vertical_speed = 0;
    float horizontal_speed = 0;
    float max_speed = Initilize.player_max_speed;
    float acceleration = Initilize.player_acceleration;
    float deceleration = Initilize.player_deceleration;
    float speed_deadzone = 1;


    void Start()
    {
        original_rotation = transform.localRotation;
        transform.localPosition = new Vector3(110, Initilize.cave_depth + 40, Initilize.cave_depth - 220);
    }

    void Update()
    {
        player_position = transform.localPosition;
        new_position = transform.localPosition;

        player_rotation = transform.localRotation;
        new_rotation = player_rotation;

        if (Input.acceleration.z < -0.9f && vertical_speed < max_speed && player_position.y < Initilize.cave_height + 35)
        {
            vertical_speed += acceleration * Time.deltaTime * (Mathf.Abs(Input.acceleration.z));
        }
        else if (Input.acceleration.z > -0.6f && vertical_speed > -max_speed && player_position.y > 38)
        {
            vertical_speed -= acceleration * Time.deltaTime * (Mathf.Abs(Input.acceleration.z));
        }
        else
        {
            if (vertical_speed > speed_deadzone)
            {
                vertical_speed -= deceleration * Time.deltaTime;
            }
            else if (vertical_speed < -speed_deadzone)
            {
                vertical_speed += deceleration * Time.deltaTime;
            }
            else
            {
                vertical_speed = 0;
            }
        }

        if (Input.acceleration.x > 0.1f && horizontal_speed < max_speed && player_position.x < Initilize.cave_width * 32)
        {
            horizontal_speed += acceleration * Time.deltaTime * System.Math.Abs(Input.acceleration.x);
        }
        else if (Input.acceleration.x < -0.1f && horizontal_speed > -max_speed && player_position.x > 5)
        {
            horizontal_speed -= acceleration * Time.deltaTime * System.Math.Abs(Input.acceleration.x);
        }
        else
        {
            if (horizontal_speed > speed_deadzone)
            {
                horizontal_speed -= deceleration * Time.deltaTime;
            }
            else if (horizontal_speed < -speed_deadzone)
            {
                horizontal_speed += deceleration * Time.deltaTime;
            }
            else
            {
                horizontal_speed = 0;
            }
        }

        if (player_position.x > Initilize.cave_width * 32)
        {
            horizontal_speed -= deceleration * 4 * Time.deltaTime;
            PlayerScore.score -= 1;
        }
        else if (player_position.x < 2)
        {
            horizontal_speed += deceleration * 4 * Time.deltaTime;
            PlayerScore.score -= 1;
        }

        if (player_position.y > Initilize.cave_height + 35)
        {
            vertical_speed += deceleration * 16 * Time.deltaTime;
            PlayerScore.score -= 1;
        }
        else if (player_position.y < 38)
        {
            vertical_speed -= deceleration * 16 * Time.deltaTime;
            PlayerScore.score -= 1;
        }

        new_position.y -= vertical_speed * 0.4f * 2;
        new_position.x += horizontal_speed * 0.6f * 2;

        transform.localPosition = Vector3.Lerp(player_position, new_position, Time.deltaTime);
        //transform.localRotation = Quaternion.RotateTowards(player_rotation, new_rotation, Time.deltaTime * 4);
    }
}*/
