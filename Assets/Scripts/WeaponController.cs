using UnityEngine;

public class WeaponController : MonoBehaviour {

	[SerializeField]
	private GameObject projectile;
	[SerializeField]
	private Transform shootPosition;

	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Instantiate(projectile, shootPosition.position, shootPosition.rotation);
		}
	}
}
