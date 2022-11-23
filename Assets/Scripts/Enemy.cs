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

    public virtual void Update() {
        //Debug.Log(hp);
    }

    public virtual void OnHit(int damage) {
        Debug.Log(hp);
        hp -= damage;
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
    }

}
