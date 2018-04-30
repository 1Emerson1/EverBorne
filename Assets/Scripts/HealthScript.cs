using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
    private const int maxHealth = 100;
    public int currentHealth;
	public const int decreaseHealth = 5;
	public TextMesh gameOverText;
	public Text healthText;

	// setup function
	void Start() {
		// set initial health
		currentHealth = maxHealth;
		
		healthText = GetComponent<Text>() as Text;

		//healthText.text = "Health: " + currentHealth.ToString();
		Debug.Log("Current health - " + currentHealth);

		// finding TextMesh object
		gameOverText = GameObject.Find("endGameText").GetComponent<TextMesh>();
		gameOverText.text = "Game over!";
	}

	// method to apply damage to player's health
	public void TakeDamage() {
		currentHealth -= decreaseHealth;

		//healthText.text = "Health: " + currentHealth.ToString();

		Debug.Log("Health - " + currentHealth);
		if(currentHealth == 0) {
			Debug.Log("Dead!");
			gameOverText.text = "You died!";
			endGame();
		}
	}

	public void endGame() {
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
}
