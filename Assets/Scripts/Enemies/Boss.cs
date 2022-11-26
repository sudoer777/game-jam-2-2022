using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public override void Awake()
    {
        this.GetComponent<Enemy>().hp = 150;
        base.Awake();
    }
}
