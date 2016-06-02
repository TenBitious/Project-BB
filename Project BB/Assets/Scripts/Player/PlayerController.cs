using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public float m_Horizontal_Axis_Left, m_Vertical_Axis_Left;
    [HideInInspector]
    public float m_Horizontal_Axis_Right, m_Vertical_Axis_Right;
    [HideInInspector]
    public Vector3 m_Direction_Move, m_Direction_Rotate;

    public float movementSpeed;
    public bool canRotate = false;
    [HideInInspector]
    public PlayerInfo m_Player_Info;

	// Use this for initialization
    public virtual void Start() 
    {
        m_Player_Info = GetComponent<PlayerInfo>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public virtual void FixedUpdate()
    {
        //Get Controller input
        GetControllerInput();

        //Handle movement and Rotation
        if(m_Player_Info.MyPlayerState == PlayerInfo.PlayerState.normal)
        {
            HandleMovement();
            GetRotation(m_Vertical_Axis_Right, m_Horizontal_Axis_Right);
        }

    }

    public virtual void GetControllerInput()
    {
        m_Horizontal_Axis_Left = Input.GetAxis("Joy_"+m_Player_Info.PlayerNumber+"_Axis_1");
        m_Vertical_Axis_Left = -Input.GetAxis("Joy_" + m_Player_Info.PlayerNumber + "_Axis_2");

        m_Horizontal_Axis_Right = -Input.GetAxis("Joy_" + m_Player_Info.PlayerNumber + "_Axis_4");
        m_Vertical_Axis_Right = Input.GetAxis("Joy_" + m_Player_Info.PlayerNumber + "_Axis_5");
    }

    public virtual void HandleMovement()
    {
        m_Direction_Move = m_Vertical_Axis_Left * Vector3.forward + m_Horizontal_Axis_Left * Vector3.right;
        m_Direction_Move *= movementSpeed;

        m_Player_Info.MyRigidbody.velocity = new Vector3(m_Direction_Move.x, m_Player_Info.MyRigidbody.velocity.y, m_Direction_Move.z);
        Debug.Log("Direction_Move: " + m_Direction_Move + " Velocity: " + m_Player_Info.MyRigidbody.velocity);
    }

    public virtual void GetRotation(float t_Axis_Vertical, float t_Axis_Horizontal)
    {
        m_Direction_Rotate = t_Axis_Vertical * Vector3.forward + t_Axis_Horizontal * Vector3.right;
        if (m_Direction_Rotate != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(m_Direction_Rotate);
        }
        //Debug.Log("Direction m:" + m_Direction_Rotate);
    }


}
