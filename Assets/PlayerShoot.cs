using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GameObject[] bullet_array;

    bool shooting = false;
    int count = 0;
    int count_bullet_speed = 0;

    void Start()
    {
        bullet_array = GameObject.FindGameObjectsWithTag("Bullet");
    }

	void Update ()
    {
		if(Input.GetButtonDown("Fire"))
        {
            bullet_array[count].transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1);
            /*if (count_bullet_speed > 2) DEAR FUTURE COREY, THIS IS AN IMPLEMENTATION OF THE AUTOFIRE POWERUP. JUST CHANGE GETBUTTONDOWN TO GETBUTTON. YOURS TRULY, PAST COREY :)
            {*/
                if (count < bullet_array.Length - 1)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                count_bullet_speed = 0;
            /*}
            else
            {
                count_bullet_speed++;
            }*/
            
            //shooting = true;
        }
        else
        {
            //shooting = false;
        }
	}
}
