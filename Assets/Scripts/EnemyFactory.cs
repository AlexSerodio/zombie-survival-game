using UnityEngine;

public class EnemyFactory : MonoBehaviour {

	[SerializeField]
	private GameObject enemy;
	[SerializeField]
	private float instantiateTime = 1;
	private float timeCounter = 0;

	// instantiate a new enemy each second
	void Update () {
		timeCounter += Time.deltaTime;

		if (timeCounter >= instantiateTime) {
			Instantiate(enemy, transform.position, transform.rotation);
			timeCounter = 0;
		}	
	}
}
