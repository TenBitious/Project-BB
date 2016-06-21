using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public KeyCode button_Shoot;

    private Dodgeball ball_Current;
    public Dodgeball Ball;

    private Vector3 ball_Start_Location;

    public float ballSpeed;

    private PlayerInfo m_Player_Info;
    private float reloadTime = 0;

	// Use this for initialization
	void Start () 
    {
        ball_Current = Ball;
        ball_Start_Location = GetComponentInChildren<ShootLocation>().transform.position;
        m_Player_Info = GetComponent<PlayerInfo>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (reloadTime > 0) reloadTime-= Time.deltaTime;
        else CheckInput();
        ball_Start_Location = GetComponentInChildren<ShootLocation>().transform.position;
	}

    void CheckInput()
    {
        if (Input.GetButtonDown("Joy_" + m_Player_Info.PlayerNumber + "_Button_5"))
        {
            if (m_Player_Info.MyPlayerState == PlayerInfo.PlayerState.normal)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Dodgeball b;
        b = Instantiate(ball_Current, ball_Start_Location, this.transform.rotation) as Dodgeball;
        Vector3 t_Ball_Velocity = -this.transform.forward * ballSpeed;
        b.SetVelocity(t_Ball_Velocity);
        reloadTime = m_Player_Info.ReloadTime;
    }
   

}
