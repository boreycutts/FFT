using UnityEngine;
using System.Collections;
using CnControls;

public class RotatePlayer : MonoBehaviour
{
    Quaternion original_rotation = new Quaternion();
    Quaternion player_rotation = new Quaternion();

    void Start()
    {
        original_rotation = transform.localRotation;
    }

    void Update()
    {
        if (Initilize.is_mobile)
        {
            player_rotation = transform.localRotation;

            if (CnControls.CnInputManager.GetAxis("LeftHorizontal") > 0.2f)
            {
                transform.Rotate(0, -9 * CnControls.CnInputManager.GetAxis("LeftHorizontal"), 0);
            }
            else if (CnControls.CnInputManager.GetAxis("LeftHorizontal") < -0.2f)
            {
                transform.Rotate(0, 9 * -CnControls.CnInputManager.GetAxis("LeftHorizontal"), 0);
            }
            else
            {
                transform.localRotation = Quaternion.Lerp(player_rotation, original_rotation, Time.deltaTime * 4);
            }
            // TILT CONTROLS
            /*player_rotation = transform.localRotation;

            if (Input.acceleration.x > Initilize.controller_deadzone)
            {
                transform.Rotate(0, -8, 0);
            }
            else if (Input.acceleration.x < -Initilize.controller_deadzone)
            {
                transform.Rotate(0, 8, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Lerp(player_rotation, original_rotation, Time.deltaTime * 4);
            }*/
        }
        else
        {
            player_rotation = transform.localRotation;

            if (Input.GetAxis("LeftHorizontal") > 0.2f)
            {
                transform.Rotate(0, -9 * Input.GetAxis("LeftHorizontal"), 0);
            }
            else if (Input.GetAxis("LeftHorizontal") < -0.2f)
            {
                transform.Rotate(0, 9 * -Input.GetAxis("LeftHorizontal"), 0);
            }
            else
            {
                transform.localRotation = Quaternion.Lerp(player_rotation, original_rotation, Time.deltaTime * 4);
            }
        }
    }
}

// MOBILE CONTROLS // 
/*using UnityEngine;
using System.Collections;

public class RotatePlayer : MonoBehaviour
{
    Quaternion original_rotation = new Quaternion();
    Quaternion player_rotation = new Quaternion();

    void Start()
    {
        original_rotation = transform.localRotation;
    }
    
    void Update()
    {
        player_rotation = transform.localRotation;

        if (Input.acceleration.x > 0.1f)
        {
            transform.Rotate(0, -9 * Input.acceleration.x, 0);
        }
        else if (Input.acceleration.x < -0.1f)
        {
            transform.Rotate(0, 9 * -Input.acceleration.x, 0);
        }
        else
        {
            transform.localRotation = Quaternion.RotateTowards(player_rotation, original_rotation, Time.deltaTime * 4);
        }   
    }
}*/
