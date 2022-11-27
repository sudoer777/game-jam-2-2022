using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebuffTimer : MonoBehaviour
{
    private static DebuffTimer _DebuffTimer;

    public static DebuffTimer Instance { get { return _DebuffTimer; } }

    public GameObject canvas;
    public GameObject deathMenu;

    TextMeshProUGUI t;
    public float dtimer;
    
    private void Awake() {
        t = GetComponent<TextMeshProUGUI>();
        ResetTimer();
        if (_DebuffTimer != null && _DebuffTimer != this)
        {
            Destroy(this.gameObject);
        } else {
            _DebuffTimer = this;
        }
        deathMenu.SetActive(false);
        Pause.ResumeGame();
    }
    
    void Update()
    {
        dtimer -= Time.deltaTime;
        if (dtimer <= 0) {
            canvas.GetComponent<DebuffMenu>().Pause();
        } else {
        t.SetText(Mathf.Floor(dtimer).ToString());
        }
        
        
        if (Player.Instance.hp <= 0)
        {
            Pause.PauseGame(deathMenu);
        }
    }
    public void ResetTimer() {
        dtimer = 30;
    }
}
