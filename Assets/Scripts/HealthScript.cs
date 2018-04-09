using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {
    private const int maxHealth = 100;
    public int currentHealth = maxHealth;
	public const int decreaseHealth = 5;

	// displays current health upon start
	void Start() {
		Debug.Log("Current health - " + currentHealth);
	}

	// method to apply damage to player's health
	public void TakeDamage() {
		currentHealth -= decreaseHealth;
		Debug.Log("Health - " + currentHealth);
		if(currentHealth <= 0) {
			currentHealth = 0;
			Debug.Log("Dead!");
			
		}
	}

    // when player collides with wall, knock player back 
	// and deduct 5 health points
    void OnCollisionEnter(Collision collision) {
		// setting knock back variables	
		var knockBack = 7500;

		if(collision.gameObject.tag == "wall") {
			// apply damage to player
			TakeDamage();

			Debug.Log("Knocking you back");
			// knock player back
			gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * knockBack);
		}
	}
}
