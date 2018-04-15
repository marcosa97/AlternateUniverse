using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
	[SerializeField]
    private Rigidbody2D rb;
	[SerializeField]
	private float velocity_x;
	[SerializeField]
	private float velocity_y;
	[SerializeField]
	private float speed = 5.0f;
	[SerializeField]
	private Vector2 total_velocity;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		velocity_x=Input.GetAxis ("Horizontal");
		velocity_y = Input.GetAxis ("Vertical");
		total_velocity = new Vector2 (velocity_x*speed, velocity_y*speed);
		rb.velocity = total_velocity;
	}
}
