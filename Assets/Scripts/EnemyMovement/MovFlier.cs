using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFlier : Enemy
{
    public int movespeed; 
    Vector3 pathToPlayer;
    
    public override void Update()
    {
        pathToPlayer = (Player.Instance.transform.position - this.transform.position).normalized;
        rb.velocity = pathToPlayer*movespeed;
    }
}
