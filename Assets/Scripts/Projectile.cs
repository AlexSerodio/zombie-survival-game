using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private AudioClip deathSound;

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
		if (other.CompareTag ("Enemy")) {
			Destroy(other.gameObject);

			// plays the death sound
			AudioController.instance.PlayOneShot(deathSound);
		}

		Destroy(gameObject);
	}
}
