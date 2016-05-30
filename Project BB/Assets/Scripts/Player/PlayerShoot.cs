using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public KeyCode button_Shoot;

    private Dodgeball ball_Current;
    public Dodgeball Ball;

    private Vector3 ball_Start_Location;

    public float ballSpeed;

	// Use this for initialization
	void Start () 
    {
        ball_Current = Ball;
        ball_Start_Location = GetComponentInChildren<ShootLocation>().transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckInput();
        ball_Start_Location = GetComponentInChildren<ShootLocation>().transform.position;
	}

    void CheckInput()
    {
        if (Input.GetButtonDown("Joy_1_Button_5"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Dodgeball b;
        b = Instantiate(ball_Current, ball_Start_Location, this.transform.rotation) as Dodgeball;
        Vector3 t_Ball_Velocity = -this.transform.forward * ballSpeed;
        b.SetVelocity(t_Ball_Velocity);
        Debug.Log("Ball Vel: " + t_Ball_Velocity);
    }
   

}
