using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour {

	[SerializeField] private Slider healthSlider;

	private PlayerController playerController; 

	void Start () {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

		healthSlider.maxValue = playerController.playerStatus.health;
		UpdateHealthSlider();
	}

	public void UpdateHealthSlider () {
		healthSlider.value = playerController.playerStatus.health;
	}
}
