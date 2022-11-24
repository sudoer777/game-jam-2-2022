using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovLeaper : Enemy
{
    public int movespeed; 
    private float lifespan = 0;
    Vector3 pathToPlayer;
    
    public override void Update()
    {
        if ((lifespan % 2) < 1.5 && ((lifespan + Time.deltaTime) % 2) > 1.5) { 
            pathToPlayer = (Player.Instance.transform.position - this.transform.position).normalized;
        }
        UpdateLifespan();
        if ((lifespan % 2) > 1.5) {
            rb.velocity = pathToPlayer*movespeed;
        }
    }
    public void UpdateLifespan() {
        lifespan += Time.deltaTime;
    }
}
