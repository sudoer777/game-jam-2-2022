using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    private static Player _Player;

    public static Player Instance { get { return _Player; } }

    private void Awake()
    {
        if (_Player != null && _Player != this)
        {
            Destroy(this.gameObject);
        } else {
            _Player = this;
        }
    }
}
