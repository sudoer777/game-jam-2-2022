using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffMenu : MonoBehaviour
{

    public static bool paused = false;

    private static DebuffMenu _DebuffMenu;

    public static DebuffMenu Instance { get { return _DebuffMenu; } }

    public GameObject mainCamera;
    public GameObject debuffMenuUI;

    public void Awake () {
        debuffMenuUI.SetActive(false);
        if (_DebuffMenu != null && _DebuffMenu != this)
        {
            Destroy(this.gameObject);
        } else {
            _DebuffMenu = this;
        }
    }

    public void Pause () {
        debuffMenuUI.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    } 

    public void Resume () {
        debuffMenuUI.SetActive(false);
        Time.timeScale = 1;
        DebuffTimer.Instance.ResetTimer();
        paused = false;
    }
    public void DebuffAttack () {
        Player.Instance.DebuffAttack();
        Resume();      
    }
    public void DebuffVision () {   
        mainCamera.GetComponent<CameraScroll>().DebuffVision();
        Resume();
    }
    public void DebuffStamina () {
        Player.Instance.GetComponent<PlayerMove>().DebuffStamina();
        Resume();
    }
}