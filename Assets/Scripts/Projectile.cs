using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField]
	private float speed;

	void FixedUpdate () {
		GetComponent<Rigidbody>().MovePosition(
			GetComponent<Rigidbody>().position + (transform.forward * speed * Time.deltaTime));
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Enemy"))
			Destroy(other.gameObject);

		Destroy(gameObject);
	}
}
