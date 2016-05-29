using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour {

    Rigidbody m_Rigidbody;

    private float m_Horizontal_Axis_Left, m_Vertical_Axis_Left;
    private float m_Horizontal_Axis_Right, m_Vertical_Axis_Right;

    private Vector3 m_Direction_Move, m_Direction_Rotate;

    public float movementSpeed;


	// Use this for initialization
	void Start () 
    {
        m_Rigidbody = GetComponent<Rigidbody>();
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
        m_Horizontal_Axis_Left = Input.GetAxis("P1_Horizontal_Left");
        m_Vertical_Axis_Left = Input.GetAxis("P1_Vertical_Left");

        m_Horizontal_Axis_Right = Input.GetAxis("P1_Horizontal_Right");
        m_Vertical_Axis_Right = Input.GetAxis("P1_Vertical_Right");
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
