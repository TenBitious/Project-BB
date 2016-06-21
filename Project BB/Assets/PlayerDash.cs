using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour {

    public int button_Dash;
    private PlayerInfo m_Player_Info;    
    private readonly float MIMIMUNVEL = 0.1f; // Minimun velocity to stop dash state

    // Use this for initialization
    void Start () {
        m_Player_Info = GetComponent<PlayerInfo>(); // Get player info
    }
	
	// Update is called once per frame
	void Update () {
        CheckInput(); 
        if (m_Player_Info.MyPlayerState == PlayerInfo.PlayerState.dash)
        {
            if (HorizontalVelocityMagnitude() <= MIMIMUNVEL)
            {
                EndDash();
            }
        }
    }

    /// <summary>
    /// Calculates the magnitude of the horizontal velocity of the player
    /// </summary>
    /// <returns></returns>
    private float HorizontalVelocityMagnitude()
    {
        Vector3 playerVelocity= m_Player_Info.MyRigidbody.velocity; // Get the velocity of the rigidbody
        return new Vector3(playerVelocity.x, 0, playerVelocity.z).magnitude; // Return the magnitude of the velocity without velocity in the y-axis
    }

    void CheckInput()
    {
        if (Input.GetButtonDown("Joy_" + m_Player_Info.PlayerNumber + "_Button_" + button_Dash))
        {
            if (m_Player_Info.MyPlayerState == PlayerInfo.PlayerState.normal)
            StartDash();
        }
    }

    private void StartDash()
    {
        m_Player_Info.MyPlayerState = PlayerInfo.PlayerState.dash; // Set playerstate to dash       
        Vector3 walkDirection = GetComponent<PlayerController>().DirectionMove.normalized; // Get walk direction       
        m_Player_Info.MyRigidbody.velocity = walkDirection * m_Player_Info.DashPower; // Dash towards walk direction
    }

    private void EndDash()
    {
        m_Player_Info.MyPlayerState = PlayerInfo.PlayerState.normal; // Set playerstate back to normal
    }

}
