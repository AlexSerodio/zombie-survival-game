using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Rigidbody rigidbodyProjectile;

	void Start () {
		rigidbodyProjectile = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		rigidbodyProjectile.MovePosition(
			rigidbodyProjectile.position + (transform.forward * speed * Time.deltaTime));
	}

	// Destroy the projectile and the enemy
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Enemy"))
			Destroy(other.gameObject);

		Destroy(gameObject);
	}
}
