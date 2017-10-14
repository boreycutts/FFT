using UnityEngine;
using System.Collections;

public class MovePoint1 : MonoBehaviour
{
    Vector3 bar_position;
    int count = 0;
    int limit = Initilize.cave_depth;

    public Material[] color_array = new Material[11];

    void Start()
    {
        bar_position = transform.localPosition;

        GetComponent<MeshRenderer>().material = color_array[PlayerColor.color2];
    }

    void Update()
    {
        count++;
        if (count > limit)
        {
            transform.position = bar_position;
            gameObject.tag = "Bar";
            count = 0;
        }

        transform.Translate(0, 1, -6); // Default = 0.8f, -4, Make a linear function that scales these two values evenly
    }
}
