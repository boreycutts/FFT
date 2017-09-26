using UnityEngine;
using System.Collections;

public class MovePoint : MonoBehaviour
{
    Vector3 bar_position;
    int count = 0;
    int limit = Initilize.cave_depth;

    public Material[] color_array = new Material[11];

	void Start ()
    {
        bar_position = transform.localPosition;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().material = color_array[PlayerColor.color2];
	}

	void Update ()
    {
        count++;
        if (count > limit)
        {
            GetComponent<Renderer>().enabled = false;
            transform.position = bar_position;
            gameObject.tag = "Bar";
            GetComponent<Renderer>().enabled = true;
            count = 0;
        }


            if (transform.localPosition.z < -220)
            {
                GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        

        transform.Translate(0, 1, -6); // Default = 0.8f, -4, Make a linear function that scales these two values evenly
	}
}
