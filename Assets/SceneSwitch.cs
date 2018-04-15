using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneSwitch : MonoBehaviour {
	private bool isWaiting;
	// Use this for initialization
	void Start () {
		isWaiting = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWaiting) {
			StartCoroutine ("WaitTenSeconds");
		} else {
			//TODO: Press space to switch to other map.
		}
	}

	IEnumerator WaitTenSeconds()
	{
		yield return new WaitForSecondsRealtime (10.0f);

	}
}