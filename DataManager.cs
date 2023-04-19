using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager I;
    string path;


    public void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(this);
        }
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();
    }


    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            JsonMake();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if(saveData != null)
            {
                for(int i = 0; i < saveData.isVisit.Length; i++)
                {
                    GameManager.I.isVisit[i] = saveData.isVisit[i];
                }
                for (int i = 0; i < saveData.ending.Length; i++)
                {
                    GameManager.I.ending[i] = saveData.ending[i];
                    Debug.Log("¿¨;");
                }
                GameManager.I.continueScene = saveData.continueScene;

                GameManager.I.isVisit = saveData.isVisit;
                GameManager.I.ending = saveData.ending;
            }
        }
    }

    public void JsonMake()
    {
        SaveData saveData = new SaveData();

        for (int i = 0; i < 21; i++)
        {
            saveData.isVisit[i] = false;
        }
        for (int i = 0; i < 10; i++)
        {
            saveData.ending[i] = false;
        }
        GameManager.I.continueScene = "Scene1";
        saveData.continueScene = GameManager.I.continueScene;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        for (int i = 0; i < 21; i++)
        {
            saveData.isVisit[i] = GameManager.I.isVisit[i];
        }
        for (int i = 0; i < 10; i++)
        {
            saveData.ending[i] = GameManager.I.ending[i];
        }
        saveData.continueScene = GameManager.I.continueScene;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

}
