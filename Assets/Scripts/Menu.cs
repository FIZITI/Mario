using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("level1");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
