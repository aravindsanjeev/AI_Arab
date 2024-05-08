using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AI_DataManager : MonoBehaviour
{
    [SerializeField] string configFileName = "Config.JSON";
    [SerializeField] string configPath;
    [SerializeField] GameEvent Event_DataLoaded;
    public AI_FilesModelClass DataObject = new AI_FilesModelClass();


    #region Singleton
    public static AI_DataManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    private void OnEnable()
    {
        configPath = Path.Combine(Application.streamingAssetsPath, configFileName);
        ReadFiles();
    }

    private void ReadFiles()
    {
        string jsonData = System.IO.File.ReadAllText(configPath);
        var data = JsonUtility.FromJson<AI_FilesModelClass>(jsonData);

        if (data == null)
        {
            Debug.Log("No Files");
        }
        else
        {
            Debug.Log("Files");
            DataObject.paths = new path();
            DataObject.paths = data.paths;

            Event_DataLoaded?.InvokeEvent();
        }
    }
}
