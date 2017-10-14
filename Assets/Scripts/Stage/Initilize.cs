using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Initilize : MonoBehaviour
{
    // This is where you can tweak the settings of the project

    // Application Settings //
    static public bool is_mobile = true; // Specifies whether the player is mobile (true) or pc (false)
    static public int mobile_ui_scale_factor = 1; // Increases the size of ui. Is dependent on the variable "is_mobile" (default = 1)

    // Cave Settings //
    static public int cave_depth = 55; // Changes the depth of the cave (default = 55)
    static public int cave_height = 180; // Changes the height of the cave (default = 130)
    static public int cave_width = 13; // Changes the width of the cave (default = 6)
    static public int cave_intensity;// = 500; // Changes the amplitude scaling factor of blocks (default = 800)
    static public int block_width = 55; // Changes the width of the individual blocks (default = 25)
    static public int number_of_blocks = 64;

    // Player Settings // 
    static public int player_max_speed = 130; // Changes the max speed the player can reach (default = 110)
    static public int player_acceleration = 500; // Changes the player acceleration (default = 1000)
    static public int player_deceleration = 200; // Changes the player deceleration (default = 200)
    static public int player_score = 2000; // Changes the player's inital score (default = 5000)
    static public int coin_score = 100; // Changes the score given to the player for collecting a coin (default = 100)
    static public int deduction_rate = 25; // Changes the deductions from hitting a block for 1 frame (default = 25)
    static public float controller_deadzone = 0.1f; // Changes the deadzone of the movement axis +- this value (default = 0.2)
    public Mesh[] player_model_array = new Mesh[3];
    static public Mesh player_model;
    static public int model_index = 0;
    static public int color1 = 0;
    static public int color2 = 0;

    // Camera Settings //
    static public float camera_speed = 2f; // Changes the camera speed (default = 0.015)
    static public float camera_lag = 4; // Changes the distance the camera lags behind the player (default = 4)


    void Awake()
    {
        Application.targetFrameRate = 60;
        player_model = player_model_array[model_index];

        if (is_mobile)
        {
            mobile_ui_scale_factor = 2;

            cave_depth = 40;
            cave_height = 200;
            cave_width = 13 * 2;
            //cave_intensity = 600;
            block_width = 52 * 2;
            number_of_blocks = 32;

            player_max_speed = 130;
            player_acceleration = 1200;
            player_deceleration = 400;
            player_score = 2000;
            coin_score = 100;
            deduction_rate = 25;

            camera_speed = 4f;
            camera_lag = 4;
        }
    }

    void Start ()
    {

        /*if (is_mobile)
        {
            mobile_ui_scale_factor = 2;

            cave_depth = 40;
            cave_height = 200;
            cave_width = 16;
            cave_intensity = 600;
            block_width = 70;
            number_of_blocks = 16;

            player_max_speed = 130;
            player_acceleration = 1200;
            player_deceleration = 400;
            player_score = 2000;
            coin_score = 100;
            deduction_rate = 25;

            camera_speed = 4f;
            camera_lag = 4;
        }*/
    }

    void Update ()
    {
        
    }
}
