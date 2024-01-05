using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
[System.Serializable]
public class UserData
{

    public string name = "Default";
    public int score = 0;
}
public class UserDataManager : MonoBehaviour
{
    public static UserDataManager instance;
    public UserData userData;
    private UserData localUserData;
    public UserData maxLocalData;
    private string path;
    // Start is called before the first frame update
     void Awake()
    {
        path = Application.persistentDataPath + "/saveData.json";
        loadData();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public void saveData()
    {
        if(userData.score > localUserData.score)
        {
            File.WriteAllText(path, JsonUtility.ToJson(NewSaveData(userData)));
            maxLocalData = userData;
        }
    }



    public void loadData()
    {
        if (File.Exists(path))
        {
            localUserData = JsonUtility.FromJson<SaveData>(File.ReadAllText(path)).userData;
            if(localUserData == null)
            {
                localUserData = new UserData();
            }
            userData = CopyUserData(localUserData);
        }
        else
        {
            userData = new UserData();
            localUserData = new UserData();
        }
        maxLocalData = localUserData;
    }


  
    private UserData CopyUserData(UserData saveData)
    {
        UserData data = new UserData();
        data.name = saveData.name;
        data.score = saveData.score;
        return  data;
    }

    private SaveData NewSaveData(UserData userData)
    {
        SaveData saveData = new SaveData();
        saveData.userData = userData;
        return saveData;
    }

    [System.Serializable]
    class SaveData
    {
        public UserData userData;
    }

    


}
