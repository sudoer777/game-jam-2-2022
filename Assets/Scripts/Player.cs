using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    private static Player _Player;

    public static Player Instance { get { return _Player; } }

    public int hp = 5;
    public float iframes = 0;
    public float power = 7; 

    private void Awake() {
        if (_Player != null && _Player != this)
        {
            Destroy(this.gameObject);
        } else {
            _Player = this;
        }
    }
    
    private void Update() {
        if (iframes > 0) {
            iframes -= Time.deltaTime;
        }
    }

    public void Heal() {
        hp += 1;
    }

    public void Hit() {
        hp -= 1;
        iframes = 1;
    }

    public void DebuffAttack() {
        power *= 0.8f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            if (iframes <= 0) {
                Hit();
            }
        }
    }
}
