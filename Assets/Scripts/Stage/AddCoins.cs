using UnityEngine;
using System.Collections;

public class AddCoins : MonoBehaviour
{
    int count = 0;
    int count2 = 0;

    Vector3 current_coin_position;

    GameObject[] coin_array;

	void Start ()
    {
        coin_array = GameObject.FindGameObjectsWithTag("Coin");
        current_coin_position = new Vector3(96, Initilize.cave_height/2, 0);
    }

	void Update ()
    {
        count++;
        if (count >  40 - BuildGround.average * 300)
        {
            count2++;

            if (count2 > coin_array.Length - 1)
            {
                count2 = 0;
            }
            
            coin_array[count2].transform.localPosition = new Vector3(Random.Range(current_coin_position.x - 50, current_coin_position.x + 50), Random.Range(current_coin_position.y - 30, current_coin_position.y + 30), -4);

            if (coin_array[count2].transform.localPosition.x > Initilize.cave_width * Initilize.number_of_blocks/2 - 20)
            {
                Debug.Log("x > ");
                coin_array[count2].transform.localPosition = new Vector3(Initilize.cave_width * Initilize.number_of_blocks / 2 - 20, coin_array[count2].transform.localPosition.y, coin_array[count2].transform.localPosition.z);
            }
            else if (coin_array[count2].transform.localPosition.x < 10)
            {
                Debug.Log("x < ");
                coin_array[count2].transform.localPosition = new Vector3(10, coin_array[count2].transform.localPosition.y, coin_array[count2].transform.localPosition.z);
            }

            if (coin_array[count2].transform.localPosition.y > Initilize.cave_height)
            {
                Debug.Log("y > ");
                coin_array[count2].transform.localPosition = new Vector3(coin_array[count2].transform.localPosition.x, Initilize.cave_height - 20 , coin_array[count2].transform.localPosition.z);
            }
            else if (coin_array[count2].transform.localPosition.y < 5 + 20)
            {
                Debug.Log("y < ");
                coin_array[count2].transform.localPosition = new Vector3(coin_array[count2].transform.localPosition.x, 20, coin_array[count2].transform.localPosition.z);
            }

            current_coin_position = coin_array[count2].transform.localPosition;
            count = 0;
        }
	}
}
