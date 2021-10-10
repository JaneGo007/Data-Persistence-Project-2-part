using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public string nickNameInput;
    public static Menu Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        StartCoroutine("Helper"); }
    IEnumerator Helper() {
        while (true) {
            print("nickName - " + nickNameInput);
            yield return new WaitForSeconds(3f); } }


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
