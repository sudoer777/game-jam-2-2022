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
        if (this.transform.position.x < -1 || this.transform.position.x > 16 || this.transform.position.y < 1 || this.transform.position.y > 13) {
            Destroy(this.gameObject);
        }
    }
    public void Fire(float projectileSpeed, Vector3 direction) {
        rb.velocity = direction * projectileSpeed;
    }

}