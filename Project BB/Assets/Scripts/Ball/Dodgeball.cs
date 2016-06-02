using UnityEngine;
using System.Collections;

public class Dodgeball : MonoBehaviour
{
    public enum DodgeballState { active = 1, nonActive = 2, pickable = 3, hitObject};
    private DodgeballState m_State;
    public DodgeballState State
    {
        get
        {
            return m_State;
        }
        set
        {
            m_State = value;
        }
    }
    Rigidbody m_rigidBody;
    public float destroyTime;
    private string ownerName;
    private GameObject owner;
    public Vector3 ballVelocity;
    public float power = 2;
    [HideInInspector]
    public bool useGravity = true;
    [HideInInspector]
    public float inAirTime = 1;

    public bool unstoppable = false;

    // Use this for initialization
    void Start()
    {
       // Destroy(gameObject, destroyTime);
        
    }

    void Awake()
    {
        m_State = DodgeballState.active;
        m_rigidBody = GetComponent<Rigidbody>();
       // m_rigidBody.useGravity = useGravity;
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
                pKB.StartKnockBack(transform.position, m_rigidBody.velocity, power);
                Debug.Log("Hit player");
                Destroy(this.gameObject);
            }
            //Destroy(this.gameObject);
        }
    }

    public void SetVelocity(Vector3 p_velocity)
    {
        m_rigidBody.velocity = p_velocity;
       // velocityDir = p_velocity;

    }
    public string OwnerName  { get { return this.ownerName; } set { this.ownerName = value; } }

}
