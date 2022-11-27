using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("SFX")) PlayerPrefs.SetInt("SFX", 1);
        if (!PlayerPrefs.HasKey("Menu")) PlayerPrefs.SetInt("Menu", 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Toggle(string setting)
    {
        PlayerPrefs.SetInt(setting, PlayerPrefs.GetInt(setting) == 0 ? 1 : 0);
    }
}
