using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBubble : Enemy
{
    public override void Awake()
    {
        this.GetComponent<Enemy>().hp = 20;
        base.Awake();
    }
}
