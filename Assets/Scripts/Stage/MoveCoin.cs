using UnityEngine;
using System.Collections;

public class MoveCoin : MonoBehaviour
{
    static public int count = 0;
    public Material[] color_array = new Material[11];

    void Start ()
    {
        GetComponent<MeshRenderer>().material = color_array[PlayerColor.color1];
    }
    void Update()
    {
        transform.localScale = new Vector3(2 + BuildGround.average * 50, 2 + BuildGround.average * 50, 2);
        transform.Translate(0, 1f, -6);
    }
}
