using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyButtonLink : MonoBehaviour
{
    public string text;
    public string key;
    public TextMeshProUGUI textGUI;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textGUI.text = text + PlayerPrefs.GetString(key);
    }
}
