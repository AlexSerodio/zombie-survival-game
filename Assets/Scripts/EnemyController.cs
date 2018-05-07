using UnityEngine;

public class EnemyController : MonoBehaviour, IKillable {

	[SerializeField] private AudioClip deathSound;

	private Status enemyStatus;
	private GameObject player;
	private CharacterMovement enemyMovement;
	private CharacterAnimation enemyAnimation;
	private Vector3 randomPosition;
	private Vector3 direction;
	private float rollingCounter;
	private float randomPositionTime = 4;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");		
		enemyMovement = GetComponent<CharacterMovement>();
		enemyAnimation = GetComponent<CharacterAnimation>();
		enemyStatus = GetComponent<Status>();

		GetRandomEnemy();
	}

	void FixedUpdate () {

		// get the distance between this enemy and the player
		float distance = Vector3.Distance(transform.position, player.transform.position);

		enemyMovement.Rotation(direction);
		enemyAnimation.Movement(direction.magnitude);

		if (distance > 15) {
			Rolling();
		} else if (distance > 2.5f) {
			// get the final position, that is, 
			// the distance between the enemy and the player
			direction = player.transform.position - transform.position;

			// checks if enemy and player are not colliding.
			// The 2.5f is because both enemy and player have a Capsule Collider with radius equal 1,
			// so if the distance is bigger than both radius they are colliding
			enemyMovement.Movement(direction, enemyStatus.speed);

			// if they're not colliding the Attacking animation is off
			enemyAnimation.Attack(false);
		} else {
			// otherwise, the Attacking animation is on
			enemyAnimation.Attack(true);
		}
	}

	/// <summary>
	/// Attacks the player, causing a random damage between 20 and 30.
	/// </summary>
	void AttackPlayer () {
		int damage = Random.Range(20, 30);
		player.GetComponent<PlayerController>().LoseHealth(damage);
	}

	void GetRandomEnemy () {
		// gets a random enemy
		// (the Zombie prefab has 27 different zombie models inside it)
		int randomEnemy = Random.Range(1, 28);
		transform.GetChild(randomEnemy).gameObject.SetActive(true);
	}

    public void LoseHealth(int damage)
    {
        enemyStatus.health -= damage;
		if (enemyStatus.health <= 0)
			Die();
    }

    public void Die()
    {
        Destroy(gameObject);

		// plays the death sound
		AudioController.instance.PlayOneShot(deathSound);
    }

	private void Rolling () {
		rollingCounter -= Time.deltaTime;
		if (rollingCounter <= 0) {
			randomPosition = GetRandomPosition();
			rollingCounter += randomPositionTime;
		}

		bool closeEnough = Vector3.Distance(transform.position, randomPosition) <= 0.1;
		if (closeEnough == false) {
			direction = randomPosition - transform.position;
			enemyMovement.Movement(direction, enemyStatus.speed);
		}
	}

	private Vector3 GetRandomPosition () {
		Vector3 position = Random.insideUnitSphere * 10;
		position += transform.position;
		position.y = transform.position.y;
		return position;
	}
}
