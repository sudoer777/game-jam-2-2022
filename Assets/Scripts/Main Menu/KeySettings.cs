using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySettings : MonoBehaviour
{
    private string settingToUpdate = "";
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Up")) PlayerPrefs.SetString("Up", KeyCode.W.ToString());
        if (!PlayerPrefs.HasKey("Down")) PlayerPrefs.SetString("Down", KeyCode.S.ToString());
        if (!PlayerPrefs.HasKey("Left")) PlayerPrefs.SetString("Left", KeyCode.A.ToString());
        if (!PlayerPrefs.HasKey("Right")) PlayerPrefs.SetString("Right", KeyCode.D.ToString());
        if (!PlayerPrefs.HasKey("Sprint")) PlayerPrefs.SetString("Sprint", KeyCode.Space.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (settingToUpdate != "")
        {
            if (UnityEngine.Input.anyKey)
            {
                foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
                    if(Input.GetKey(vKey)){
                        PlayerPrefs.SetString(settingToUpdate, vKey.ToString());
                        settingToUpdate = "";
                        return;
                    }
                }
            }
        }
    }

    public void Reset()
    {
        PlayerPrefs.SetString("Up", KeyCode.W.ToString());
        PlayerPrefs.SetString("Down", KeyCode.S.ToString());
        PlayerPrefs.SetString("Left", KeyCode.A.ToString());
        PlayerPrefs.SetString("Right", KeyCode.D.ToString());
        PlayerPrefs.SetString("Sprint", KeyCode.Space.ToString());
    }

    public void Set(string setting)
    {
        PlayerPrefs.SetString(setting, "");
        settingToUpdate = setting;
    }
}
