using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
   public float delay = 5.0f;
    private float countDown;
    private float radius;
    private float force;
    private bool hasExploded = false;
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        radius = 3.0f;
        force = 700.0f;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0.0f && !hasExploded) 
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode() 
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // collider detecting //

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders) 
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if(rb != null) 
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
        FindObjectOfType<GameManager>().addScore();
    }
}
