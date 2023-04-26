using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Vector3 startPos;
    public float range;
    private void Start()
    {
        startPos = transform.position;
    }





    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(Vector2.Distance(transform.position, startPos) >= range)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject );
    }
}
