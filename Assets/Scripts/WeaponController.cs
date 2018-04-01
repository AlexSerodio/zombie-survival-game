using UnityEngine;

public class WeaponController : MonoBehaviour {

	[SerializeField] private GameObject projectile;
	[SerializeField] private Transform shootPosition;
	[SerializeField] private AudioClip shotSound;

	void Update () {
		// instantiates a new projectile each mouse click
		if (Input.GetButtonDown("Fire1")) {
			Instantiate(projectile, shootPosition.position, shootPosition.rotation);

			// plays the shot sound
			AudioController.instance.PlayOneShot(shotSound);
		}
	}
}
