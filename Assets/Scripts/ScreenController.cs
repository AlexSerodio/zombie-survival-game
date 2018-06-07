using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour {

	[SerializeField] private Slider healthSlider;
	[SerializeField] private GameObject gameOverPanel;
	[SerializeField] private Text scoreText;
	[SerializeField] private Text maxScoreText;
	[SerializeField] private Text deadZombiesText;
	private float maxScore;
	private int deadZombiesCount;
	
	private PlayerController playerController; 

	void Start () {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

		maxScore = PlayerPrefs.GetFloat("MaxScore");

		healthSlider.maxValue = playerController.playerStatus.health;
		UpdateHealthSlider();
		Time.timeScale = 1;
	}

	public void UpdateHealthSlider () {
		healthSlider.value = playerController.playerStatus.health;
	}

	public void GameOver () {
		gameOverPanel.SetActive(true);
		Time.timeScale = 0;

		float time = Time.timeSinceLevelLoad;

		int minutes = (int)(time / 60);
		int seconds = (int)(time % 60);
		scoreText.text = "You survived for " + minutes + " minutes and " + seconds + " seconds.";
		UpdateMaxScore(minutes, seconds, time);
	}

	public void Restart () {
		SceneManager.LoadScene("Game");
	}
	
	public void UpdateDeadZombiesCount () {
		deadZombiesCount++;
		deadZombiesText.text = string.Format("x {0}", deadZombiesCount);
	}

	private void UpdateMaxScore (int minutes, int seconds, float time) {
		if (time > maxScore) {
			maxScore = time;
			maxScoreText.text = string.Format("Your best time is {0} minutes and {1} seconds.", minutes, seconds);
			PlayerPrefs.SetFloat("MaxScore", maxScore);
		} else {
			time = PlayerPrefs.GetFloat("MaxScore");
			minutes = (int)(time / 60);
			seconds = (int)(time % 60);
			maxScoreText.text = string.Format("Your best time is {0} minutes and {1} seconds.", minutes, seconds);
		}
	}
}
