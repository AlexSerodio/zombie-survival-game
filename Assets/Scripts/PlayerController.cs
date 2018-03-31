using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Vector3 direction;

	void Update () {

		// player movement inputs. Stores the X and Z direction using the pressed keys
		float xAxis = Input.GetAxis("Horizontal");
		float zAxis = Input.GetAxis("Vertical");

		// creates a Vector3 with the new direction
		direction = new Vector3 (xAxis, 0, zAxis);

		// player animations transition
		if (direction != Vector3.zero)
			GetComponent<Animator>().SetBool("Running", true);
		else
			GetComponent<Animator>().SetBool("Running", false);
	}
		
	void FixedUpdate () {
		// moves the player by second using physics
		// use physics (rigidbody) to compute the player movement is better than transform.position 
		// because prevents the player to "bug" when colliding with other objects
		GetComponent<Rigidbody>().MovePosition(
			GetComponent<Rigidbody>().position + (direction * Time.deltaTime * speed));
	}
}
