using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFlier : Enemy
{
    public int movespeed; 
    Vector3 pathToPlayer;
    
    public override void Update()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) >= 50f) {
            return;
        }
        pathToPlayer = (Player.Instance.transform.position - this.transform.position).normalized;
        rb.velocity = pathToPlayer*movespeed;
        base.Update();
    }
}
