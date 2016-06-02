using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {


    private SpawnPoint spawnPoint;
    public bool canSpawn = true;
    public Vector3 spawnPosition;
    
 
	// Use this for initialization
	void Start () {
        spawnPoint = GetComponentInChildren<SpawnPoint>();
        spawnPosition = spawnPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
