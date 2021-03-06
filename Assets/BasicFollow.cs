﻿using System.Collections;
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
    private float switchTime = 5.0f;
    private float timer;
    public bool isWandering;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (timer <= switchTime)
        {
            timer += Time.deltaTime;
        }
        float distance = Vector2.Distance(Player.instance.GetPosition(), (Vector2)transform.position);
        if (distance < detectRadius)
        {
            moveDirection = Player.instance.GetPosition() - (Vector2)transform.position;
            moveDirection.Normalize();
            rb.velocity = moveDirection * moveSpeed;
            return;
        }
        if (timer >= switchTime && isWandering)
        {
            timer = 0;
            moveDirection = Random.insideUnitCircle;
            moveDirection.Normalize();
        }
        if (isWandering)
            rb.velocity = moveDirection * moveSpeed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
