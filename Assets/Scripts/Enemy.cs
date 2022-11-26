using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float hp;

    protected Rigidbody2D rb;

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //this.GetComponent<Enemy>().hp = 20 is the way to set HP in a subclass
    public virtual void Update() {
    }

    public virtual void OnHit(float damage) {
        hp -= damage;
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
    }

}
