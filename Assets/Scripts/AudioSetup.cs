using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetup : MonoBehaviour
{
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<AudioSource>().mute = PlayerPrefs.HasKey(type) && PlayerPrefs.GetInt(type) == 0;
    }

    private void Awake()
    {
    }
}
