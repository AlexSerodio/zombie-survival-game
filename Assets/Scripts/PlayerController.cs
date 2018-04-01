using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject gameOverText;
	public bool isAlive = true;
	[SerializeField]
	private float speed;
	[SerializeField]
	private LayerMask groundMask;
	private Vector3 direction;
	private Rigidbody rigidbodyPlayer;
	private Animator animatorPlayer;

	void Start () {
		// Start the game without been paused
		Time.timeScale = 1;

		rigidbodyPlayer = GetComponent<Rigidbody>();
		animatorPlayer = GetComponent<Animator>();
	}

	void Update () {

		// player movement inputs. Stores the X and Z direction using the pressed keys
		float xAxis = Input.GetAxis("Horizontal");
		float zAxis = Input.GetAxis("Vertical");

		// creates a Vector3 with the new direction
		direction = new Vector3 (xAxis, 0, zAxis);

		// player animations transition
		if (direction != Vector3.zero)
			animatorPlayer.SetBool("Running", true);
		else
			animatorPlayer.SetBool("Running", false);

		// if the player isn't alive anymore 
		// and the mouse button was clicked, restart the game
		if (!isAlive) {
			if (Input.GetButtonDown ("Fire1"))
				SceneManager.LoadScene("Game");
		}
	}
		
	void FixedUpdate () {
		// moves the player by second using physics
		// use physics (rigidbody) to compute the player movement is better than transform.position 
		// because prevents the player to "bug" when colliding with other objects
		rigidbodyPlayer.MovePosition(
			rigidbodyPlayer.position + (direction * Time.deltaTime * speed));

		// makes the player rotation follows the mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100, groundMask)) {
			Vector3 positionPoint = hit.point - transform.position;
			positionPoint.y = transform.position.y;
			Quaternion newRotation = Quaternion.LookRotation(positionPoint);
			rigidbodyPlayer.MoveRotation(newRotation);
		}
	}
}
