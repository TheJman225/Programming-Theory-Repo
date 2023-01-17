using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
