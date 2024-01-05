using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

using TMPro;

public class GuiUiHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject InputObj = GameObject.Find("InputField");
        TMP_InputField nameTMP = InputObj.GetComponent<TMP_InputField>();
        nameTMP.text = UserDataManager.instance.userData.name;

        GameObject TitleObj = GameObject.Find("Title");
        Text titleTMP = TitleObj.GetComponent<Text>();
        titleTMP.text ="Best Score : "+ UserDataManager.instance.userData.name+" : "+UserDataManager.instance.userData.score;
    }

    public void SetUserName(string name)
    {
        UserDataManager.instance.userData.name = name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }
    public void QuitGame()
    {
        UserDataManager.instance.saveData();
#if (UNITY_EDITOR)
        EditorApplication.ExitPlaymode();
#else
                Application.Quit();
#endif

    }


}
