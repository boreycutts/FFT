using UnityEngine;
using System.Collections;
using System.Threading;
using CnControls;

public class MoveCamera : MonoBehaviour
{
    float speed = Initilize.camera_speed;
    private int count = 0;
    Quaternion original_rotation = new Quaternion();
    Quaternion camera_rotation = new Quaternion();
    Quaternion new_rotation = new Quaternion();
    Vector3 original_position = new Vector3();
    Vector3 camera_position = new Vector3();
    Vector3 new_position = new Vector3();
    float acceleration = 1f;

    void Start()
    {
        if (Initilize.is_mobile)
        {
            camera_position = transform.localPosition;
            original_position = camera_position;
            camera_position.x = -8;
            camera_position.y = 6;
            camera_position.z = -10;
            transform.localPosition = camera_position;
            Camera.main.backgroundColor = new Color(0.2f, 0.2f, 0.4f);
            original_rotation = Camera.main.transform.localRotation;
        }
        else
        {
            camera_position = transform.localPosition;
            original_position = camera_position;
            camera_position.x = -8;
            camera_position.y = 6;
            camera_position.z = -10;
            transform.localPosition = camera_position;
            Camera.main.backgroundColor = new Color(0.2f, 0.2f, 0.4f);
            //Thread thread1 = new Thread(backgroundColor);
            original_rotation = Camera.main.transform.localRotation;
        }
    }

    void Update()
    {
        if (Initilize.is_mobile)
        {
            camera_rotation = Camera.main.transform.localRotation;
            new_rotation = original_rotation;

            new_position = Camera.main.transform.localPosition;
            new_position.y = 3;
            new_position.z = -10;// FUTURE IMPLEMENTATION: Dynamic Camera Angle --> -4 - BuildGround.average * 600;

            if (CnControls.CnInputManager.GetAxis("LeftHorizontal") > 0.4f)
            {
                new_rotation.z = -0.2f;
                new_position.x = Initilize.camera_lag;
            }
            else if (CnControls.CnInputManager.GetAxis("LeftHorizontal") < -0.4f)
            {
                new_rotation.z = 0.2f;
                new_position.x = -Initilize.camera_lag;
            }
            else
            {
                new_position.x = 0;
            }

            if (CnControls.CnInputManager.GetAxis("LeftVertical") < -0.4f)
            {
                new_rotation.x = 0.2f;
                new_position.y = Initilize.camera_lag;

            }
            else if (CnControls.CnInputManager.GetAxis("LeftVertical") > 0.4f)
            {
                new_rotation.x = -0.2f;
                new_position.y = -Initilize.camera_lag;
            }

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new_position, Time.deltaTime * speed);
            transform.localRotation = Quaternion.Lerp(camera_rotation, new_rotation, Time.deltaTime * 0.5f);
        
        // TILT CONTORLS
        /*camera_rotation = Camera.main.transform.localRotation;
        new_rotation = original_rotation;

        new_position = Camera.main.transform.localPosition;
        new_position.y = 3;
        new_position.z = -10;// FUTURE IMPLEMENTATION: Dynamic Camera Angle --> -4 - BuildGround.average * 600;

        if (Input.acceleration.x > Initilize.controller_deadzone)
        {
            new_rotation.z = -0.2f;
            new_position.x = Initilize.camera_lag;
        }
        else if (Input.acceleration.x < -Initilize.controller_deadzone)
        {
            new_rotation.z = 0.2f;
            new_position.x = -Initilize.camera_lag;
        }
        else
        {
            new_position.x = 0;
        }

        if (Input.acceleration.z < -0.8f - Initilize.controller_deadzone)
        {
            new_rotation.x = 0.2f;
            new_position.y = Initilize.camera_lag;

        }
        else if (Input.acceleration.z > -0.8f + Initilize.controller_deadzone)
        {
            new_rotation.x = -0.2f;
            new_position.y = -Initilize.camera_lag;
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new_position, Time.deltaTime * speed);
        transform.localRotation = Quaternion.Lerp(camera_rotation, new_rotation, Time.deltaTime * 0.5f);*/
    }
        else
        {
            camera_rotation = Camera.main.transform.localRotation;
            new_rotation = original_rotation;

            new_position = Camera.main.transform.localPosition;
            new_position.y = 3;
            new_position.z = -10;// FUTURE IMPLEMENTATION: Dynamic Camera Angle --> -4 - BuildGround.average * 600;

            if (Input.GetAxis("LeftHorizontal") > 0.4f)
            {
                new_rotation.z = -0.2f;
                new_position.x = Initilize.camera_lag;
            }
            else if (Input.GetAxis("LeftHorizontal") < -0.4f)
            {
                new_rotation.z = 0.2f;
                new_position.x = -Initilize.camera_lag;
            }
            else
            {
                new_position.x = 0;
            }

            if (Input.GetAxis("LeftVertical") > 0.4f)
            {
                new_rotation.x = 0.2f;
                new_position.y = Initilize.camera_lag;

            }
            else if (Input.GetAxis("LeftVertical") < -0.4f)
            {
                new_rotation.x = -0.2f;
                new_position.y = -Initilize.camera_lag;
            }

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new_position, Time.deltaTime * speed);
            transform.localRotation = Quaternion.Lerp(camera_rotation, new_rotation, Time.deltaTime * 0.5f);
        }
    }
}

// MOBILE CONTROLS // 
/*using UnityEngine;
using System.Collections;
using System.Threading;

public class MoveCamera : MonoBehaviour
{
    float speed = Initilize.camera_speed;
    private int count = 0;
    Color original_color = new Color();
    Color background_color = new Color();
    Color new_color = new Color();
    Quaternion original_rotation = new Quaternion();
    Quaternion camera_rotation = new Quaternion();
    Quaternion new_rotation = new Quaternion();
    Vector3 original_position = new Vector3();
    Vector3 camera_position = new Vector3();
    Vector3 new_position = new Vector3();
    float acceleration = 1f;

    void Start()
    {
        camera_position = transform.localPosition;
        original_position = camera_position;
        camera_position.x = -8;
        camera_position.y = 6;
        camera_position.z = -10;
        transform.localPosition = camera_position;
        Camera.main.backgroundColor = new Color(0.2f, 0.2f, 0.4f);
        original_color = new Color(0.2f, 0.1f, 0.1f); // Camera.main.backgroundColor;
        Thread thread1 = new Thread(backgroundColor);
        original_rotation = Camera.main.transform.localRotation;
    }

    void Update()
    {
        camera_rotation = Camera.main.transform.localRotation;
        new_rotation = original_rotation;

        new_position = Camera.main.transform.localPosition;
        new_position.y = 3;
        new_position.z = -10;// FUTURE IMPLEMENTATION: Dynamic Camera Angle --> -4 - BuildGround.average * 600;

        if (Input.acceleration.x > 0.1f)
        {
            new_rotation.z = -0.2f;
            new_position.x = Initilize.camera_lag;
        }
        else if (Input.acceleration.x < -0.1f)
        {
            new_rotation.z = 0.2f;
            new_position.x = -Initilize.camera_lag;
        }
        else
        {
            new_position.x = 0;
        }

        if (Input.acceleration.z < -0.8f)
        {
            new_rotation.x = 0.2f;
            new_position.y = Initilize.camera_lag;
            
        }
        else if (Input.acceleration.z > -0.7f)
        {
            new_rotation.x = -0.2f;
            new_position.y = -Initilize.camera_lag;
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new_position, Time.deltaTime * speed);
        transform.localRotation = Quaternion.Lerp(camera_rotation, new_rotation, Time.deltaTime * 0.5f);
        backgroundColor();
    }

    void backgroundColor()
    {
        background_color = Camera.main.backgroundColor;
        new_color = background_color;
        new_color.r = original_color.r * BuildGround.average * 100;
        Camera.main.backgroundColor = Color.Lerp(background_color, new_color, Mathf.PingPong(Time.time, 4f) / 4f);
    }
}*/
