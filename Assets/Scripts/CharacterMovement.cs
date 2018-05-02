using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody myRigidbody;

	void Awake () {
		myRigidbody = GetComponent<Rigidbody>();
	} 
	
	public void Movement (Vector3 direction, float speed) {
		// moves the enemy as in the PlayerController but 
		// instead using the GetAxis method it uses the normalized direction vector
		myRigidbody.MovePosition (
			myRigidbody.position + (direction.normalized * Time.deltaTime * speed));
	}

	public void Rotation (Vector3 direction) {
		// rotates the enemy towards the player
		Quaternion newRotation = Quaternion.LookRotation (direction);
		myRigidbody.MoveRotation (newRotation);
	}

}
