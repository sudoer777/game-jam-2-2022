using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBubble : Enemy
{
    public override void Awake()
    {
        this.GetComponent<Enemy>().hp = 30;
        base.Awake();
    }
}
