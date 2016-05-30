using UnityEngine;
using System.Collections;

public class ControllerDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        for (int z = 1; z < 5; z++)
        {
            for (int i = 1; i < 16; i++)
            {
                if (Input.GetAxis("Joy_"+z+"_Axis_" + i) != 0)
                {
                    Debug.Log("Controller: " +z+ "Axis " + i + ": " + Input.GetAxis("Joy_" + z + "_Axis_" + i));
                }

            }
            for (int i = 0; i < 16; i++)
            {
                if (Input.GetButtonDown("Joy_" + z + "_Button_" + i))
                {
                    Debug.Log("Controller: " + z + "Button " + i + " pressed " + Input.GetButtonDown("Joy_" + z + "_Button_" + i));
                }
            }
        }
	    
	}
}
