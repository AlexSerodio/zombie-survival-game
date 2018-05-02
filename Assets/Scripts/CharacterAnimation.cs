using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

	private Animator animator;

	void Awake () {
		animator = GetComponent<Animator>();
	}

	public void Attack (bool state) {
		animator.SetBool("Attacking", state);
	}

	public void Movement (float value) {
		animator.SetFloat("Running", value);
	}
}
