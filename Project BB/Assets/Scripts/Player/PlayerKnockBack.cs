using UnityEngine;
using System.Collections;

public class PlayerKnockBack : MonoBehaviour {

    private readonly float MIMIMUNVEL = 0.1f;

    private PlayerInfo m_PlayerInfo;
	// Use this for initialization

	void Start () 
    {
        m_PlayerInfo = GetComponent<PlayerInfo>();
	}

    void FixedUpdate()
    {
        if (m_PlayerInfo.MyPlayerState == PlayerInfo.PlayerState.knockback)
        { 
            if (m_PlayerInfo.MyRigidbody.velocity.magnitude <= MIMIMUNVEL)
            {
                EndKnockback();
            }
        }
    }

    public void StartKnockBack(float ballPower)
    {
        // Decrease its mass
        this.GetComponent<Rigidbody>().mass *= (100 - ballPower)/100;

        //Set Playerstate
        m_PlayerInfo.MyPlayerState = PlayerInfo.PlayerState.knockback;
    }

    void EndKnockback()
    {
        Debug.Log("End Knockback");
        m_PlayerInfo.MyPlayerState = PlayerInfo.PlayerState.normal;
    }
}
