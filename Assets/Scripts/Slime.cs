using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public override void Awake()
    {
        this.GetComponent<Enemy>().hp = 20;
        Debug.Log(hp);
        base.Awake();
    }

    public override void Update()
    {
        //Debug.Log(hp);        
        base.Update();
    }
}
