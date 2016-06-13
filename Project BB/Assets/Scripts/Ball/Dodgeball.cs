using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody), typeof(SphereCollider))]
public class Dodgeball : MonoBehaviour
{
    // State of the ball
    public enum DodgeballState { active = 1, nonActive = 2, pickable = 3, hitObject};
    private DodgeballState m_State;

    private Rigidbody m_rigidBody;
    private GameObject owner;
    private string ownerName;

    public float destroyTime;
    public Vector3 ballVelocity;
    [Tooltip("Between 0 and 100")]
    public float power = 2;
    [HideInInspector]
    public bool useGravity = true;
    [HideInInspector]
    public float inAirTime = 1;
    [HideInInspector]
    public bool useVerticalVelocity = false;
    [HideInInspector]
    public float AngleForYAxis;
    public bool unstoppable = false;

    void Awake()
    {
        m_State = DodgeballState.active;
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.useGravity = useGravity;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAirTime();
    }

    private void CheckAirTime()
    {
        inAirTime -= Time.deltaTime;
        if (inAirTime < 0 && m_State == DodgeballState.active)
        {
            SetNonActive();
        }
    }

    private void SetHitObject()
    {
        m_rigidBody.useGravity = true;
        if (!unstoppable) m_rigidBody.velocity = Vector3.zero;
        m_State = DodgeballState.hitObject;
        //Debug.Log("Set ball hitobject");
    }

    private void SetNonActive()
    {
        Debug.Log("Set ball nonactive");
        m_rigidBody.useGravity = true;
        m_State = DodgeballState.nonActive;  
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.name);
        if (m_State == DodgeballState.active)
        {
            
            if (col.gameObject.tag == "Player" && col.gameObject.name != OwnerName)
            {
                SetHitObject();
                PlayerKnockBack pKB = col.gameObject.GetComponent<PlayerKnockBack>();
                pKB.StartKnockBack(power);
                Destroy(this.gameObject);
            }
        }
    }

    public void SetVelocity(Vector3 p_velocity)
    {
        m_rigidBody.velocity = Quaternion.AngleAxis(-AngleForYAxis, new Vector3(p_velocity.z, 0, -p_velocity.x)) * p_velocity;
    }
    public string OwnerName
    {
        get { return this.ownerName; }
        set { this.ownerName = value; }
    }

    public DodgeballState State
    {
        get { return m_State; }
        set { m_State = value; }
    }
}
