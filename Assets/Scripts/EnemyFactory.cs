using System.Collections;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

	[SerializeField] private GameObject enemy;
	[SerializeField] private float instantiateTime = 1;
	[SerializeField] private LayerMask enemyLayer;
	private float instantiationDistance = 3;
	private float playerDistance = 20;
	private float timeCounter = 0;
	private GameObject player;

	void Start () {
		player = GameObject.FindWithTag("Player");
	}

	// instantiates a new enemy each second
	void Update () {
		if (Vector3.Distance(transform.position, player.transform.position) > playerDistance) {
			timeCounter += Time.deltaTime;

			if (timeCounter >= instantiateTime) {
				StartCoroutine(InstantiateNewEnemy());
				timeCounter = 0;
			}	
		}		
	}

	private IEnumerator InstantiateNewEnemy () {
		Vector3 position = GetRandomPosition();
		Collider[] colliders = Physics.OverlapSphere(position, 1, enemyLayer);
		
		while (colliders.Length > 0) {
			position = GetRandomPosition();
			colliders = Physics.OverlapSphere(position, 1, enemyLayer);
			yield return null;
		}
		
		Instantiate(enemy, position, transform.rotation);
	}

	private Vector3 GetRandomPosition () {
		Vector3 position = Random.insideUnitSphere * instantiationDistance;
		position += transform.position;
		position.y = 0;
		return position;
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, instantiationDistance);
	}
}
