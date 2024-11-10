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
    public int score;
    public InputField nameInputField;
    public GameObject inputName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private void Start()
    {

    }

    private void OnGUI()
    {

        GUI.Label(new Rect(10, 20, 300, 50), "Name: " + playerName);
        GUI.Label(new Rect(10, 60, 300, 50), "Score: " + score);
    }

    public void StartNew()
    {
        if (nameInputField.text != null)
            MenuManager.Instance.playerName = nameInputField.text;
        else if (playerName != null && nameInputField.text == null)
            MenuManager.Instance.playerName = playerName;
        MenuManager.Instance.score = 0;
        SceneManager.LoadScene(1);
    }

    public void SaveName()
    {

        SaveData data = new SaveData();
        data.playerName = playerName ;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        print("Data Saved");
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            score = data.score;
        }
        print("Data Loaded");
    }




}
[System.Serializable]
class SaveData
{
    public string playerName;
    public int score;
}
