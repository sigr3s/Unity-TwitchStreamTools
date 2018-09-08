using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchLib.Unity;
using TwitchLib.Client.Models;



public static class TwitchClient{
    private static Client _client;
    public static Client Client {
        get
        {
            if (!isInitialized)
            {
                Initialize();
            }
            return _client;
        }
    }

    private static bool isInitialized = false;

    private static void Initialize() {
        Application.runInBackground = true;
        ConnectionCredentials cc = new ConnectionCredentials(TwitchConfiguration.BotName, TwitchConfiguration.BotAccessToken);
        _client = new Client();
        string channelName = PlayerPrefs.GetString("channelName", "sigr3s");
        _client.Initialize(cc, channelName);
        _client.Connect();
        isInitialized = true;
    }
}
