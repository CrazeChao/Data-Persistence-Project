using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MaxScore : MonoBehaviour
{

    UserData old;
    Text titleText;
    // Start is called before the first frame update
    void Start()
    {
        titleText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UserData maxUser = UserDataManager.instance.maxLocalData;
        titleText.text = "Best Score : "+  maxUser.score+" Name: "+ maxUser.name;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("guide");
        }
    }
}
