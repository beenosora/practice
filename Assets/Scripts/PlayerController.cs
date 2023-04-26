using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    public float jumpHeight = 5f;
    public LayerMask mask;
    public Transform groundCheck;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Jump();
    }
    void Moving()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        if (x != 0)
        {
            rb.velocity = new Vector2(x, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, x > 0 ? 0 : 180, 0);
        }
    }
    void Jump()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(1.1f, 0.14f), 0, mask);
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
            Destroy(other.gameObject, 0);
    }
}
