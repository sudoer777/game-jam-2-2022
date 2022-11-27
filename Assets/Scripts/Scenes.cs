using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Pause.ResumeGame(); 
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); 
    }

    public void Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Options");
    }

    public void Controls()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
    }

    public void Sound()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Sound");
    }
}
