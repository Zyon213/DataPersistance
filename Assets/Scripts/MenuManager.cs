using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string playerName;
    public InputField nameInputField;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    private void Start()
    {
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.playerName = playerName ;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        playerName = nameInputField.text;
        SaveColor();


    }
}