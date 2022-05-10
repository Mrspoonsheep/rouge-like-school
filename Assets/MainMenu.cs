using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene("Scene1");
    }
}
   
