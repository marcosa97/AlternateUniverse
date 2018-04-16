using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinChecker : MonoBehaviour {
	public int numCoinsInLevel;
	public Text winText;

	void OnTriggerEnter2D(Collider2D other) {
		if ( other.gameObject.CompareTag("Player") ) {
			if (other.gameObject.GetComponent<Player>().GetPickUpsCount() == numCoinsInLevel) {
				//Won Game! Yay!
				Debug.Log("YOU WON");
				winText.text = "YOU WON!";
			}
		}
	}
}
