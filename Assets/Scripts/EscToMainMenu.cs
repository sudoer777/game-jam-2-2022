using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscToMainMenu : MonoBehaviour
{
    public GameObject escapeMenu;

    public void Awake () {
        escapeMenu.SetActive(false);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.Toggle(escapeMenu);
        }
    }

    public void Cancel()
    {
        Pause.ResumeGame(escapeMenu);
    }
}
