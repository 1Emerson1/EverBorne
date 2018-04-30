using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text counterText;
	public float seconds, minutes;
	public float timeLeft = 300.0f;
	public GameObject player;

	// Use this for initialization
	void Start () {
		counterText = GetComponent<Text>() as Text;
		StartCoroutine("LoseTime");
		Time.timeScale = 1;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		minutes = (int)(timeLeft/60f);
		seconds = (int)(timeLeft % 60f);

		counterText.text = "Time Left: " + minutes.ToString() + ":" + seconds.ToString("00");

		if(timeLeft == 0) {
			timeLeft = 0;
			Debug.Log("Time is up!");
		}
	}

	IEnumerator LoseTime() {
		while (true) {
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}
}
