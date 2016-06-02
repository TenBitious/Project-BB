using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    public enum PlayerState { normal = 1, stunned = 2, knockback = 3 }

    private PlayerState m_Player_State;
    public int playerNumber;

    private Rigidbody m_Rigidbody;



	// Use this for initialization
	void Start () 
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Player_State = PlayerState.normal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int PlayerNumber
    {
        get { return playerNumber; }
    }
    public Rigidbody MyRigidbody
    {
        get { return m_Rigidbody; }
    }
    public PlayerState MyPlayerState
    {
        get { return m_Player_State; }
        set { m_Player_State = value; }
    }
}
