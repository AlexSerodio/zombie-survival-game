using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private Transform player;
	private Vector3 distance;

	void Start () {
		distance = transform.position - player.position;
	}

	void Update () {
		transform.position = player.position + distance;
	}
}
