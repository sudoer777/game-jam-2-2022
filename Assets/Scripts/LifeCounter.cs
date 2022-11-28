using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCounter : MonoBehaviour
{
    private static LifeCounter _LifeCounter;

    public static LifeCounter Instance { get { return _LifeCounter; } }

    TextMeshProUGUI t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TextMeshProUGUI>();
        if (_LifeCounter != null && _LifeCounter != this)
        {
            Destroy(this.gameObject);
        } else {
            _LifeCounter = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        t.SetText((Player.Instance.hp).ToString());
    }
}
