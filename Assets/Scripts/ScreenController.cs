using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour {

	[SerializeField] private Slider healthSlider;

	private PlayerController playerController; 

	void Start () {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

		healthSlider.maxValue = playerController.health;
		UpdateHealthSlider();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateHealthSlider () {
		healthSlider.value = playerController.health;
	}
}
