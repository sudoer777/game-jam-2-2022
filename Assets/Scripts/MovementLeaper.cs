using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLeaper : Enemy
{
    int movespeed = 9; 
    Vector3 pathToPlayer;
    
    public void Update()
    {
        if ((lifespan % 2) < 1.5 && ((lifespan + Time.deltaTime) % 2) > 1.5) { 
            pathToPlayer = (Player.Instance.transform.position - this.transform.position).normalized;
        }
        UpdateLifespan();
        if ((lifespan % 2) > 1.5) {
            RaycastHit hit;
            rb.velocity = pathToPlayer*movespeed;
            //rb.velocity = pathToPlayer*movespeed;
            /*if (!Physics.Raycast(transform.position, pathToPlayer, out hit, Mathf.Infinity, LayerMask.NameToLayer("Object")))
            {
                
            }*/

        }
    }
    public void UpdateLifespan() {
        lifespan += Time.deltaTime;
    }
}
