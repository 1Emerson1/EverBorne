using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public GameObject Parent;
    private const int maxHealth = 100;
    public const int decreaseHealth = 5;
    public int currentHealth = maxHealth;

	// displays current health upon start
	void start() {
		Debug.Log("Current health - " + currentHealth);
	}

    // when player(sphere) collides with wall, deduct 5 points
    void OnCollisionEnter(Collision collision) {

		// setting knock back variables
		var knockBack = 5000;
		var force = transform.position - collision.transform.position;
		force.Normalize();

		// if health hits 0, quit game
		if (currentHealth != 0) {
			if(collision.gameObject.tag == "wall") {
				Debug.Log("Whoops, you hit a wall!");
				// knocks player back
				Debug.Log("Pushing you back!");
				//gameObject.Get

				// decreases health
				Debug.Log("Player Health has decreased by " + decreaseHealth + " points");
				currentHealth -= decreaseHealth;

				// displays current health
				Debug.Log("Current Health : " + currentHealth);
			}
		} else {
			Debug.Log("You're dead, ripperoni");
			Application.Quit();
		}
    }
}
