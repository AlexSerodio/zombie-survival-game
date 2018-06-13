using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	[SerializeField] private GameObject quitButton;
	
	// Use this for initialization
	void Start () {
		#if UNITY_STANDALONE || UNITY_EDITOR
			quitButton.SetActive(true);
		#endif
	}
	
	public void PlayGame() {
		StartCoroutine(ChangeScene("Game"));
	}

	IEnumerator ChangeScene(string scene) {
		yield return new WaitForSeconds(.1f);
		SceneManager.LoadScene(scene);
	}

	public void QuitGame() {
		StartCoroutine(Quit());
	}
	
	IEnumerator Quit () {
		yield return new WaitForSeconds(.1f);
		Application.Quit();
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}
