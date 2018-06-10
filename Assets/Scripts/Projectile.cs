using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] private float speed;
	private Rigidbody rigidbodyProjectile;

	void Start () {
		rigidbodyProjectile = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		// moves the projectile forward using physics (rigidbody)
		rigidbodyProjectile.MovePosition(
			rigidbodyProjectile.position + (transform.forward * speed * Time.deltaTime));
	}

	// Destroy the projectile and the enemy
	void OnTriggerEnter (Collider other) {
		switch (other.tag) {
			case "Enemy":
				other.GetComponent<EnemyController>().LoseHealth(1);
				break;
			case "Boss":
				other.GetComponent<BossController>().LoseHealth(1);
				break;
		}

		

		Destroy(gameObject);
	}
}
