using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    public enum PlayerState { normal = 1, dash = 2, knockback = 3 }

    private PlayerState m_Player_State;
    public int playerNumber;
    public float playerMass;
    public float dashPower;
    public float reloadTime;

    private Rigidbody m_Rigidbody;



	// Use this for initialization
	void Start () 
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.mass = playerMass; // Set player's mass
        m_Player_State = PlayerState.normal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int PlayerNumber { get { return playerNumber; } }
    public float DashPower { get { return dashPower; } }
    public float ReloadTime { get { return reloadTime; } }
    public Rigidbody MyRigidbody { get { return m_Rigidbody; } }
    public PlayerState MyPlayerState
    {
        get { return m_Player_State; }
        set { m_Player_State = value; }
    }


    /// <summary>
    /// Resets velocity and mass
    /// </summary>
    public void ResetPlayer()
    {
        m_Rigidbody.mass = playerMass;
        m_Rigidbody.velocity = Vector3.zero;
    }
}
