using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollow : MonoBehaviour {
    [SerializeField]
    private float detectRadius;
    private Vector2 playerLocation;
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(Player.instance.GetPosition(), (Vector2)transform.position);
        if (distance < detectRadius)
        {
            moveDirection = Player.instance.GetPosition() - (Vector2)transform.position;
            moveDirection.Normalize();
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
