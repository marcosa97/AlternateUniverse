using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    private Vector2 arrowDir;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2.0f);
        arrowDir = Player.instance.GetBowRotation();
    }

    void FixedUpdate()
    {
        rb.velocity = arrowDir * speed;
    }
}
