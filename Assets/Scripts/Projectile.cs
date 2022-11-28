using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
    private float projectileSpeed;
    public float lifespan = 0;
    private Renderer rend;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*lifespan += Time.deltaTime;
        if(/*!GetComponent<Renderer>().isVisible && #1#lifespan > 1.5){
            Destroy(this.gameObject);
        }*/
    }
    public void Fire(float projectileSpeed, Vector3 direction) {
        rb.velocity = direction * projectileSpeed;
        var angle = Vector3.Angle(new Vector3(0.0f, 1.0f, 0.0f), direction);
        if (direction.x > 0.0f) angle = 360.0f - angle;
        angle += 90f;
        rb.SetRotation(angle);
    }

}