using UnityEngine;

public class PlayerMovement : CharacterMovement {

	public void PlayerRotation (LayerMask groundMask) {
		// makes the player rotation follows the mouse position
		// it uses a LayerMask that computes only the Raycasts that collide with the ground
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100, groundMask)) {
			Vector3 positionPoint = hit.point - transform.position;
			positionPoint.y = transform.position.y;
			
			Rotation(positionPoint);
		}
	}
}
