using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    static public int score;

    int count = 0;
    int count2 = 0;

    //public Material dead_material;
    public Material[] dead_materials = new Material[2];

    GameObject[] deduction_array;
    GameObject[] coin_score;

    void Start ()
    {
        score = Initilize.player_score;
        deduction_array = GameObject.FindGameObjectsWithTag("Deduction");
        coin_score =  GameObject.FindGameObjectsWithTag("CoinScore");
        GetComponent<MeshFilter>().mesh = Initilize.player_model;
    }

	void Update ()
    {
		if (score <= 0)
        {
            GetComponent<Renderer>().materials = dead_materials;
        }
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Contains("Coin") && score > 0)
        {
            if (score < Initilize.player_score)
            {
                score += Initilize.coin_score;
            }
            MoveCoinScore.count = 0;
            coin_score[0].transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (score > 0 && !collision.gameObject.tag.Contains("Bullet"))
        {
            score -= Initilize.deduction_rate;
            count2++;

            if (count2 > 8)
            {
                count2 = 0;
            }

            MoveCoin.count = 0;
            deduction_array[count2].transform.localPosition = MovePlayer.player_position;
        }
    }
}
