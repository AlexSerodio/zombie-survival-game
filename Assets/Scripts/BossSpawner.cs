using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

	[SerializeField] private GameObject bossPrefab;
	private float nextSpawnTime;
	private float timeBetweenSpawns = 60;
	
	// Use this for initialization
	void Start () {
		nextSpawnTime = timeBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > nextSpawnTime) {
			Instantiate(bossPrefab, transform.position, Quaternion.identity);
			nextSpawnTime += timeBetweenSpawns;
		}
	}
	
	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 1.5f);
	}
}
