using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	void Update () {

		float xAxis = Input.GetAxis("Horizontal");
		float zAxis = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(xAxis, 0, zAxis);

		transform.Translate(direction * Time.deltaTime * speed);		
	}
}
