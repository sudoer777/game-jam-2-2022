using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause
{
    public static bool paused = false;
    public static void PauseGame(GameObject menu)
    {
        Time.timeScale = 0;
        paused = true;
        menu.SetActive(true);
    }

    public static void ResumeGame(GameObject? menu = null)
    {
        Time.timeScale = 1;
        paused = false;
        if(menu) menu.SetActive(false);
    }

    public static void Toggle(GameObject menu)
    {
        if (paused) ResumeGame(menu);
        else PauseGame(menu);
    }
}
