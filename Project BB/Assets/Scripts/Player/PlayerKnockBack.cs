using UnityEngine;
using System.Collections;

public class PlayerKnockBack : MonoBehaviour {

    private readonly float MIMIMUNVEL = 0.1f;

    private PlayerInfo m_Player_Info;
	// Use this for initialization

	void Start () 
    {
        m_Player_Info = GetComponent<PlayerInfo>();
	}

    void FixedUpdate()
    {
        if (m_Player_Info.MyPlayerState == PlayerInfo.PlayerState.knockback)
        {
            if (HorizontalVelocityMagnitude() <= MIMIMUNVEL)
            {
                EndKnockback();
            }
        }
    }
    private float HorizontalVelocityMagnitude()
    {
        Vector3 playerVelocity = m_Player_Info.MyRigidbody.velocity;
        return new Vector3(playerVelocity.x, 0, playerVelocity.z).magnitude;
    }

    public void StartKnockBack(float ballPower)
    {
        // Decrease its mass
        this.GetComponent<Rigidbody>().mass *= (100 - ballPower)/100;

        //Set Playerstate
        m_Player_Info.MyPlayerState = PlayerInfo.PlayerState.knockback;
    }

    void EndKnockback()
    {
        m_Player_Info.MyPlayerState = PlayerInfo.PlayerState.normal;
    }
}
