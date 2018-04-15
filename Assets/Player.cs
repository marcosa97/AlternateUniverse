using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
	[SerializeField]
	private Camera cam;
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
	private GameObject character;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		character = this.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		velocity_x=Input.GetAxis ("Horizontal");
		velocity_y = Input.GetAxis ("Vertical");
		total_velocity = new Vector2 (velocity_x*speed, velocity_y*speed);
		rb.velocity = total_velocity;
	}
	//Use for Camera stuff
	void LateUpdate()
	{
		cam.transform.position = new Vector3 (rb.gameObject.transform.position.x,rb.gameObject.transform.position.y,0);
	}
}
