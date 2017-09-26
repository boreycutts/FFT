using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour
{
    static public int color1;
    static public int color2; 
    public Material[] color_array;
    Material[] new_color = new Material[2];

    void Start ()
    {
        
	}
	
	void Update ()
    {
        new_color[0] = color_array[color1];
        new_color[1] = color_array[color2];
        GetComponent<MeshRenderer>().materials = new_color; 
    }
}
