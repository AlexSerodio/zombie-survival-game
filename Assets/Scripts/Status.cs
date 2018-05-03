using UnityEngine;

public class Status : MonoBehaviour {

	public int initialHealth = 100;
	[HideInInspector] public int health;
	public float speed = 5;

	// Use this for initialization
	void Start () {
		health = initialHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
