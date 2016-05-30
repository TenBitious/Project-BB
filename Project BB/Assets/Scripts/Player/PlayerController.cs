using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {

    Rigidbody m_Rigidbody;

    private float m_Horizontal_Axis_Left, m_Vertical_Axis_Left;
    private float m_Horizontal_Axis_Right, m_Vertical_Axis_Right;

    private Vector3 m_Direction_Move, m_Direction_Rotate;

    public float movementSpeed;

    private PlayerInfo m_Player_Info;

	// Use this for initialization
	void Start () 
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Player_Info = GetComponent<PlayerInfo>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void FixedUpdate()
    {
        //Get Controller input
        GetControllerInput();
        //Handle movement and Rotation
        HandleMovement();
        HandleRotation();

    }

    void GetControllerInput()
    {
        m_Horizontal_Axis_Left = Input.GetAxis("Joy_"+m_Player_Info.PlayerNumber+"_Axis_1");
        m_Vertical_Axis_Left = -Input.GetAxis("Joy_" + m_Player_Info.PlayerNumber + "_Axis_2");

        m_Horizontal_Axis_Right = -Input.GetAxis("Joy_" + m_Player_Info.PlayerNumber + "_Axis_4");
        m_Vertical_Axis_Right = Input.GetAxis("Joy_" + m_Player_Info.PlayerNumber + "_Axis_5");
    }

    void HandleMovement()
    {
        m_Direction_Move = m_Vertical_Axis_Left * Vector3.forward + m_Horizontal_Axis_Left * Vector3.right;
        m_Direction_Move *= movementSpeed;

        m_Rigidbody.velocity = new Vector3(m_Direction_Move.x, m_Rigidbody.velocity.y, m_Direction_Move.z);
        //Debug.Log("Direction_Move: " + m_Direction_Move + " Velocity: " + m_Rigidbody.velocity);
    }

    void HandleRotation()
    {
        m_Direction_Rotate = m_Vertical_Axis_Right * Vector3.forward + m_Horizontal_Axis_Right * Vector3.right;
        if (m_Direction_Rotate != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_Direction_Rotate);
        }
        //Debug.Log("Direction m:" + m_Direction_Rotate);
    }


}
