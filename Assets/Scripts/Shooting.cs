using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float fireInterval = 0.5f;
    public float timer;
    public float maxDistance = 5f;
    public float range = 10f;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= fireInterval)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            timer = 0;
        }
    }
  
}
