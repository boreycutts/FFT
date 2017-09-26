using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStoreModels : MonoBehaviour
{
    Renderer[] allChildRenderers;

    static public bool player_default = true;
    static public bool player_8bit = false;
    static public bool player_midway = false;

    Vector3 default_position = new Vector3(19, 0, 0);
    Vector3 eightbit_position = new Vector3(19 + 250/3 - 4, 0, -250);
    Vector3 midway_position = new Vector3(19 + 2*250/3 - 8, 0, -500);

    void Start()
    {
        allChildRenderers = GetComponentsInChildren<Renderer>();
    }
	void Update()
    {
        if (MoveUI.store)
        {
            foreach (Renderer R in allChildRenderers)
                R.enabled = true;
        }
        else
        {
            foreach (Renderer R in allChildRenderers)
                R.enabled = false;
        }
		if (player_default)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, default_position, Time.deltaTime*2);
            Initilize.model_index = 0;
        }
        else if (player_8bit)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, eightbit_position, Time.deltaTime*2);
            Initilize.model_index = 1;
        }
        else if (player_midway)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, midway_position, Time.deltaTime*2);
            Initilize.model_index = 2;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, default_position, Time.deltaTime*2);
            Initilize.model_index = 0;
        }
    }
}
