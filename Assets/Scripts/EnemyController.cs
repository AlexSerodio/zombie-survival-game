using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] private float speed;
	private Transform player;
	private Rigidbody rigidbodyEnemy;
	private Animator animatorEnemy;

	void Start () {
		// finds the player object
		player = GameObject.FindGameObjectWithTag("Player").transform;

		// gets a random enemy
		// (the Zombie prefab has 27 different zombie models inside it)
		int randomEnemy = Random.Range(1, 28);
		transform.GetChild(randomEnemy).gameObject.SetActive(true);

		rigidbodyEnemy = GetComponent<Rigidbody>();
		animatorEnemy = GetComponent<Animator>();
	}

	void FixedUpdate () {

		// get the distance between this enemy and the player
		float distance = Vector3.Distance(transform.position, player.position);

		// get the final position, that is, 
		// the distance between the enemy and the player
		Vector3 direction = player.position - transform.position;

		// rotates the enemy towards the player
		Quaternion newRotation = Quaternion.LookRotation (direction);
		rigidbodyEnemy.MoveRotation (newRotation);

		// checks if enemy and player are not colliding.
		// The 2.5f is because both enemy and player have a Capsule Collider with radius equal 1,
		// so if the distance is bigger than both radius they are colliding
		if (distance > 2.5f) {
			// moves the enemy as in the PlayerController but 
			// instead using the GetAxis method it uses the normalized direction vector
			rigidbodyEnemy.MovePosition (
				rigidbodyEnemy.position + (direction.normalized * Time.deltaTime * speed));

			// if they're not colliding the Attacking animation is off
			animatorEnemy.SetBool("Attacking", false);
		} else {
			// otherwise, the Attacking animation is on
			animatorEnemy.SetBool("Attacking", true);
		}
	}

	// whem the enemy atacks the player the game ends, that is, 
	// the game is paused , the Game Over message shows up
	// and the player is no more alive.
	void AttackPlayer () {
		Time.timeScale = 0;
		player.GetComponent<PlayerController>().gameOverText.SetActive(true);
		player.GetComponent<PlayerController> ().isAlive = false;
	}
}
