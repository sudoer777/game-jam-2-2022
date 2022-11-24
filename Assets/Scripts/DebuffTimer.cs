using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebuffTimer : MonoBehaviour
{
    TextMeshProUGUI t;
    private float dtimer = 120;
    void Awake() {
        t = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        dtimer -= Time.deltaTime;
        if (dtimer <= 0) {
            Time.timeScale = 0;
        }
        t.SetText(Mathf.Floor(dtimer).ToString());
    }
}
