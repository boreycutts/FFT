using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHealth : MonoBehaviour
{
    Vector3 health_scale;
    public Material[] color_array = new Material[11];
	void Start ()
    {
        GetComponent<MeshRenderer>().material = color_array[PlayerColor.color1];
	}

	void Update ()
    {
        if (PlayerScore.score <= Initilize.player_score + 1 && PlayerScore.score > 0)
        {
            health_scale = new Vector3(PlayerScore.score * 1.5f / 2000, transform.localScale.y, transform.localScale.z);
            transform.localScale = Vector3.Lerp(transform.localScale, health_scale, Time.deltaTime * 2);
        }
        else if (PlayerScore.score < 0)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
