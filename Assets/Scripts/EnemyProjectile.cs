using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
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
        if (collision.transform.tag == "Player")
        {
            // do damage here, for example:
            collision.gameObject.GetComponent<Player>().Hit();
            Destroy(this.gameObject);
        }
        else /*if (collision.transform.tag == "Wall")*/ {
            Destroy(this.gameObject);
        }
    }

}
