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
        bool foundPlayer = false;
        Collider2D[] hitcolliders = Physics2D.OverlapCircleAll(transform.position, detectRadius);

        int i = 0;
        while (i < hitcolliders.Length)
        {
            if (hitcolliders[i].tag == "Player")
            {
                playerLocation = hitcolliders[i].transform.position;
                foundPlayer = true;
                break;
            }
            i++;
        }
        moveDirection = playerLocation - (Vector2)transform.position;
        moveDirection.Normalize();

        if (foundPlayer)
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
