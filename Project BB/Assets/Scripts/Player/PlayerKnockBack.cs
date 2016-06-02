using UnityEngine;
using System.Collections;

public class PlayerKnockBack : MonoBehaviour {

    public float knockback_Time = 3;
    private float knockback_Time_Current;

    private Vector3 m_Knockback_Vel;

    private bool beingKnockbacked = false;

    private PlayerInfo m_PlayerInfo;
	// Use this for initialization
	void Start () 
    {
        m_PlayerInfo = GetComponent<PlayerInfo>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void FixedUpdate()
    {
        if (beingKnockbacked)
        {
            knockback_Time_Current -= Time.deltaTime;
            HandleKnockback();

            if (knockback_Time_Current <= 0)
            {
                EndKnockback();
            }
        }
    }
    void HandleKnockback()
    {
        //m_PlayerInfo.MyRigidbody.velocity = m_Knockback_Vel;
    }

    public void StartKnockBack(Vector3 c_Object_Pos, Vector3 c_Object_Vel, float c_Knockback_Speed)
    {
        Debug.Log("StartKnockback");
        //Set Playerstate
        m_PlayerInfo.MyPlayerState = PlayerInfo.PlayerState.knockback;

        //Set timer
        knockback_Time_Current = knockback_Time;

        Vector3 t_Knockback_Dir = (transform.position - c_Object_Pos).normalized;
        float t_Angle = Vector3.Angle(c_Object_Vel, t_Knockback_Dir);
        t_Angle = Mathf.Clamp(t_Angle, 0f, 90f);
        m_Knockback_Vel = t_Knockback_Dir * c_Knockback_Speed;
        beingKnockbacked = true;
       // m_PlayerInfo.MyRigidbody.AddForce(m_Knockback_Vel);
        Debug.Log("Knockback vel: " + m_Knockback_Vel);
    }

    void EndKnockback()
    {
        Debug.Log("EndKnockback");
        m_PlayerInfo.MyPlayerState = PlayerInfo.PlayerState.normal;
        beingKnockbacked = false;
    }
}
