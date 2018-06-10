using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour, IKillable{

	[SerializeField]private GameObject aidKitPrefab;
	
	private Transform player;
	private NavMeshAgent agent;
	private Status bossStatus;
	private CharacterAnimation bossAnimation;
	private CharacterMovement bossMovement;
	
	private void Start() {
		player = GameObject.FindWithTag("Player").transform;
		agent = GetComponent<NavMeshAgent>();
		bossStatus = GetComponent<Status>();
		agent.speed = bossStatus.speed;
		bossAnimation = GetComponent<CharacterAnimation>();
		bossMovement = GetComponent<CharacterMovement>();
	}

	private void Update() {
		agent.SetDestination(player.position);
		bossAnimation.Movement(agent.velocity.magnitude);

		if (agent.hasPath) {
			bool closeToPlayer = agent.remainingDistance <= agent.stoppingDistance;
			if (closeToPlayer) {
				bossAnimation.Attack(true);
				Vector3 direction = player.position - transform.position;
				bossMovement.Rotation(direction);
			}
			else {
				bossAnimation.Attack(false);
			}
		}
	}

	private void AttackPlayer() {
		int damage = Random.Range(30, 40);
		player.GetComponent<PlayerController>().LoseHealth(damage);
	}

	public void LoseHealth(int damage) {
		bossStatus.health -= damage;
		if (bossStatus.health <= 0) {
			Die();
		}
	}

	public void Die() {
		Destroy(gameObject, 2);
		bossAnimation.Die();
		bossMovement.Die();
		Instantiate(aidKitPrefab, transform.position, Quaternion.identity);
		enabled = false;
		agent.enabled = false;
	}
}
