using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
    private float projectileSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }
    public void Fire(float projectileSpeed, Vector3 direction) {
        rb.velocity = direction * projectileSpeed;
    }
    private void OnTriggerEnter(Collider that) {
        Destroy(this);
    }
}