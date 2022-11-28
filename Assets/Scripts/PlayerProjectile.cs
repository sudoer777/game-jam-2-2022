using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            // do damage here, for example:
            if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= 30f) {
                collision.gameObject.GetComponent<Enemy>().OnHit(Player.Instance.power * Player.Instance.gunStrength);
            }
            Destroy(this.gameObject);
        }
        else if (collision.transform.tag == "Player") return;
        else /*if (collision.transform.tag == "Wall")*/ {
            Destroy(this.gameObject);
        }
    }

}
