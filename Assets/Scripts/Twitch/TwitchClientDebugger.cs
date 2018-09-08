
using UnityEngine;
using TwitchLib.Unity;
using TwitchLib.Client.Events;

public class TwitchClientDebugger : MonoBehaviour {
    Client _client;
    public bool ShowLogs = false;
    void Start () {
        _client = TwitchClient.Client;

        _client.OnMessageSent += OnMessageSent;
        _client.OnMessageReceived += OnMessageRecieved;

        _client.OnConnected += OnConnected;
		_client.OnDisconnected += OnDisconnected;
		
		if(ShowLogs) _client.OnLog += OnLog;
		
		_client.OnConnectionError += OnConnectionError;
		_client.OnFailureToReceiveJoinConfirmation += OnJoinChannelFailure;
		_client.OnIncorrectLogin += OnIncorrectLogin;
		
		_client.OnLeftChannel += OnLeftChannel;
		_client.OnJoinedChannel += OnJoinChannel;
    }

    private void OnJoinChannel(object sender, OnJoinedChannelArgs e)
    {
        Debug.Log("<color=green> JOINED:  " + e.Channel + "</color>");
    }

    private void OnIncorrectLogin(object sender, OnIncorrectLoginArgs e)
    {
        Debug.Log("<color=red> ERROR:  " + e.Exception + "</color>");
    }

    private void OnLeftChannel(object sender, OnLeftChannelArgs e)
    {
        Debug.Log("<color=orange> LEFT:  " + e.Channel + "</color>");
    }

    private void OnJoinChannelFailure(object sender, OnFailureToReceiveJoinConfirmationArgs e)
    {
        Debug.Log("<color=red> ERROR:  " + e.Exception + "</color>");
    }

    private void OnConnectionError(object sender, OnConnectionErrorArgs e)
    {
        Debug.Log("<color=red> ERROR:  " + e.Error + "</color>");
    }

    private void OnLog(object sender, OnLogArgs e)
    {
        Debug.Log("<color=yellow> LOG:  " + e.Data + "</color>");
    }

    private void OnConnected(object sender, OnConnectedArgs e)
    {
        Debug.Log("<color=green> Connected:  " + e.BotUsername + "</color>");
    }

    private void OnDisconnected(object sender, OnDisconnectedArgs e)
    {
        Debug.Log("<color=orange> Disconnected:  " + e.BotUsername + "</color>");
    }

    private void OnMessageSent(object sender, OnMessageSentArgs e)
    {
        Debug.Log("<color=blue> MSG:  " + e.SentMessage.DisplayName + "--" + e.SentMessage.Message + "</color>");
    }

    private void OnMessageRecieved(object sender, OnMessageReceivedArgs e)
    {
        Debug.Log("<color=blue> MSG:  " + e.ChatMessage.DisplayName + "--" + e.ChatMessage.Message + "</color>");
    }

}
