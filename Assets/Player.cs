using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour {
	[SerializeField]
	private Camera cam;
	[SerializeField]
    private Rigidbody2D rb;
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private float velocity_x;
	[SerializeField]
	private float velocity_y;
	[SerializeField]
	private float speed = 5.0f;
	[SerializeField]
	private Vector2 total_velocity;
	private GameObject character;
	private bool moving;
	private int pickUpsCount;
    private Transform bowPivot;
    private Transform arrowSpawn;
    [SerializeField]
    private GameObject arrow;
    public static Player instance = null;

    // Use this for initialization
    void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		anim = gameObject.GetComponent<Animator> ();
		character = this.gameObject;
		moving = false;
		pickUpsCount = 0;
        bowPivot = transform.Find("BowPivot").transform;
        arrowSpawn = bowPivot.Find("Bow").Find("ArrowSpawn").transform;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        UpdateBow(velocity_x, velocity_y);
        Shoot();
    }

    // Update is called once per frame
    void FixedUpdate () {
		velocity_x=Input.GetAxis ("Horizontal");
		velocity_y = Input.GetAxis ("Vertical");
		total_velocity = new Vector2 (velocity_x*speed, velocity_y*speed);
		rb.velocity = total_velocity;

        //Determine if there is movement
        if (velocity_x == 0f && velocity_y == 0f) {
			moving = false;
			anim.SetBool ("moving", false);
		} else {
			moving = true;

			//Update animator
			anim.SetBool ("moving", true);
			anim.SetFloat ("LastMoveX", velocity_x);
			anim.SetFloat ("LastMoveY", velocity_y);
        }
    }
	//Use for Camera stuff
	void LateUpdate()
	{
		cam.transform.position = new Vector3 (rb.gameObject.transform.position.x,rb.gameObject.transform.position.y,0);
	}

	//For picking up collectibles
	void OnTriggerEnter2D(Collider2D other) {
		if ( other.gameObject.CompareTag("PickUp") ) {
			other.gameObject.SetActive (false);
			pickUpsCount++;
		} 
	}

    void UpdateBow(float velocity_x, float velocity_y)
    {
        if (velocity_x > 0)
            bowPivot.rotation = Quaternion.Euler(0, 0, 0);
        else if (velocity_x < 0)
            bowPivot.rotation = Quaternion.Euler(0, 0, 180);
        else if (velocity_y > 0)
            bowPivot.rotation = Quaternion.Euler(0, 0, 90);
        else if (velocity_y < 0)
            bowPivot.rotation = Quaternion.Euler(0, 0, -90);
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(arrow, arrowSpawn.position, bowPivot.rotation);
        }
    }

    public Vector2 GetBowRotation()
    {
        if (bowPivot.localRotation.eulerAngles.z == 0)
            return Vector2.right;
        else if (bowPivot.localRotation.eulerAngles.z == 180)
            return Vector2.left;
        else if (bowPivot.localRotation.eulerAngles.z == 90)
            return Vector2.up;
        else
            return Vector3.down;

    }
}
