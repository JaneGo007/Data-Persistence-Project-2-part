using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public string nickNameInput;
    public static Menu Instance;
    public TextMeshProUGUI BestScore;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }


    public class SaveData
    {
        public int BestScoreNow;
    }

    public void ReloadLoadScore()
    {

        SaveData data = new SaveData();
            data.BestScoreNow = 0;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
            print("saved");
        print(data.BestScoreNow);
    }

    public void LoadScore()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            print("loaded");
            print(data.BestScoreNow);
            BestScore.text = "Best score:" + data.BestScoreNow;
        }
    }

    private void Start()
    {

    }



    public void StartButton()
    {
 //       print("Start button pressed!");
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
//       print("Quit button pressed!");
    #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
    #else
            Application.Quit();
    #endif
    }

    public void ReadStringInput(string s)
    {
        nickNameInput = s;
//        print("Nickname: " + nickNameInput);
    }
}
