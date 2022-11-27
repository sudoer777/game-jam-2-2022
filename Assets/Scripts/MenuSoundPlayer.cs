using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
}
