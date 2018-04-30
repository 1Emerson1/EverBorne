using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	// timer variables
	public Text counterText;
	public float seconds, minutes;
	public float timeLeft;
	// health variables
    //private const int maxHealth = 100;
    public int currentHealth;
	public const int decreaseHealth = 5;
	// ui variables
	public TextMesh gameOverText;
	public Text healthText;

	// setup function
	void Start() {
		counterText = GameObject.Find("counterText").GetComponent<Text>();
		healthText = GameObject.Find("healthText").GetComponent<Text>();

		healthText.text = "Health: " + currentHealth.ToString();
		//Debug.Log("Current health - " + currentHealth);

		// initializing timer
		StartCoroutine("LoseTime");
		Time.timeScale = 1;

		// finding TextMesh object
		gameOverText = GameObject.Find("endGameText").GetComponent<TextMesh>();
		gameOverText.text = "Game over!";
	}

	// Update is called once per frame
	void Update () {
		minutes = (int)(timeLeft/60f);
		seconds = (int)(timeLeft % 60f);

		counterText.text = "Time Left: " + minutes.ToString() + ":" + seconds.ToString("00");

		if(timeLeft == 0) {
			gameOverText.text = "Time is up!";
			endGame();
		}
	}

	// method to apply damage to player's health
	public void TakeDamage() {
		currentHealth -= decreaseHealth;

		healthText.text = "Health: " + currentHealth.ToString();

		Debug.Log("Health - " + currentHealth);
		if(currentHealth == 0) {
			Debug.Log("Dead!");
			gameOverText.text = "You died!";
			endGame();
		}
	}

	// teleports player to end game area
	public void endGame() {
		counterText.enabled = false;
		this.gameObject.transform.position = new Vector3(-12.6f, 2.7f, -31.26f);
	}

    // when player collides with wall, knock player back 
	// and deduct 5 health points
    void OnCollisionEnter(Collision collision) {
		// setting knock back variables	
		var knockBack = 5500;

		if(collision.gameObject.tag == "Minotaur") {
			// apply damage to player
			TakeDamage();
			// knock player back
			Debug.Log("Knocking you back");
			gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * knockBack);
		}
	}

	// end game method
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Finish"){
			gameOverText.text = "You won!";
			endGame();
        }
    }

	// timer method
	IEnumerator LoseTime() {
		while (timeLeft > 0) {
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}
}
