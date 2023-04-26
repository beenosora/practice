using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 leftOffSet = new Vector3(-4, 0);
    private Vector3 rightOffSet = new Vector3(4, 0);
    private Vector3 leftPatrol;
    private Vector3 rightPatrol;
    private Vector3 targetPos;
    public float speed;
    private Rigidbody2D rb;
    public float health;
    private float maxHealth = 4f;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        leftPatrol = transform.position + leftOffSet;
        rightPatrol = transform.position + rightOffSet;
        targetPos = leftPatrol;
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);

    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
        if (health == 0f)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
           
            health = health - 1f;
        healthBar.UpdateHealthBar(maxHealth, health);
    }
    private void Patrolling()
    {
        if (targetPos == leftPatrol)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
        if (Vector2.Distance(targetPos, transform.position) < 0.5f && targetPos == leftPatrol)
        {
            targetPos = rightPatrol;
        }
        if (Vector2.Distance(targetPos, transform.position) < 0.5f && targetPos == rightPatrol)
        {
            targetPos = leftPatrol;
        }
    }    
}
