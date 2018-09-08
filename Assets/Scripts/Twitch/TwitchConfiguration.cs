using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class TwitchConfiguration
{
    private const string _jsonFile = "config.json";
    private static bool _initialized = false;

    private static string _botName = "";
    public static string BotName {
        get {
            if(!_initialized) LoadConfigFromJSON(_jsonFile);
            return _botName;
        }
    }

    private static string _botAccessToken = "";
    public static string BotAccessToken  {
        get {
            if(!_initialized) LoadConfigFromJSON(_jsonFile);
            return _botAccessToken;
        }
    }

    private static string _botRefreshToken = "";
    public static string BotRefreshToken  {
        get {
            if(!_initialized) LoadConfigFromJSON(_jsonFile);
            return _botRefreshToken;
        }
    }


    public static void LoadConfigFromJSON(string jsonFile){
        string jsonPath = Application.streamingAssetsPath + Path.DirectorySeparatorChar + jsonFile;
        if(File.Exists(jsonPath)){
            string json = File.ReadAllText(jsonPath);
            var configDataModel = JsonUtility.FromJson<TwitchConfigurationDataModel>(json);

            if (string.IsNullOrEmpty(configDataModel.BotName) || string.IsNullOrEmpty(configDataModel.BotName) || 
                string.IsNullOrEmpty(configDataModel.BotName) )
            {
                _initialized = false;
                Debug.LogError("Cannot read or parse in the correct way the file: " + jsonPath);
            }
            else{
                _botName = configDataModel.BotName;
                _botAccessToken = configDataModel.BotAccessToken;
                _botRefreshToken = configDataModel.BotRefreshToken;

                _initialized = true;
            }
        }   
        else{
            _initialized = false;
            Debug.LogError("Make sure you have this file in your project: " + jsonPath);
        }
    }
}

[System.Serializable]
public class TwitchConfigurationDataModel{
    public string BotName;
    public string BotAccessToken;
    public string BotRefreshToken;
}
