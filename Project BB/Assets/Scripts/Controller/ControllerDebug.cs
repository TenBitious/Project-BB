using UnityEngine;
using System.Collections;

public class ControllerDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    for(int i = 1; i < 16; i++)
        {
            if (Input.GetAxis("Joy_1_Axis_" + i) != 0)
            {
                Debug.Log("Axis " + i + ": " + Input.GetAxis("Joy_1_Axis_" + i));
            }
                
        }
        for (int i = 0; i < 16; i++)
        {
            if(Input.GetButtonDown("Joy_1_Button_"+i))
            {
                Debug.Log("Button "+i+" pressed "+ Input.GetButtonDown("Joy_1_Button_"+i));
            }
        }
	}
}
