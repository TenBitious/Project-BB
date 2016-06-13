using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public Vector3 spawnPosition;

    private GameObject player;
    private GameObject water;
    private GameObject groundTiles;
    private Ground[] ground;
    private Ground setSpawnPoint;
    private PlayerInfo m_PlayerInfo;
    private int spawnPointIndex;


	// Use this for initialization
	void Start () {
        player = this.gameObject;
        m_PlayerInfo = GetComponent<PlayerInfo>();
        water = GameObject.FindGameObjectWithTag("Water");
        groundTiles = GameObject.FindGameObjectWithTag("GroundTiles");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Respawn()
    {
        
        ground = groundTiles.GetComponentsInChildren<Ground>();

        // Search for a spawnpoint
        do
        {
            spawnPointIndex = Random.Range(0, ground.Length - 1);
        }
        while (!ground[spawnPointIndex].canSpawn);

        setSpawnPoint = ground[spawnPointIndex];
        this.spawnPosition = setSpawnPoint.spawnPosition;

        player.gameObject.transform.position = spawnPosition;

        m_PlayerInfo.ResetPlayer();
        
    }



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == water.gameObject)
        {
            Respawn();
        }
    }
}
