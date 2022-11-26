using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
    private float projectileSpeed;
    public float lifespan = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lifespan += Time.deltaTime;
        if(!GetComponent<Renderer>().isVisible && lifespan > 2){
            Destroy(this.gameObject);
        }
    }
    public void Fire(float projectileSpeed, Vector3 direction) {
        rb.velocity = direction * projectileSpeed;
    }

}