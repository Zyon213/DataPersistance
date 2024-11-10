using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine.UI;

public class UiControl : MonoBehaviour
{
//    public InputField playerName;
    // Start is called before the first frame update
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }



    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
    public void LoadGame()
    {
        MenuManager.Instance.LoadName();
    }

    public void SaveGame()
    {
        MenuManager.Instance.SaveName();
    }

    public void StartGame()
    {
        MenuManager.Instance.StartNew();
    }

}
