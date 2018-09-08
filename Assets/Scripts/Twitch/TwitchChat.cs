
using UnityEngine;
using UnityEngine.UI;
using TwitchLib.Client.Events;
using TwitchLib.Unity;
using System.Collections.Generic;
using TMPro;

public class TwitchChat : MonoBehaviour {
    
	[Header("Message options")]
	public GameObject ChatContent;
	public GameObject TextLinePrefab;
    public InputField SentMessageInputField;
    public int MaxNumOfMessages;

    private Client _client;
	private ScrollRect _chatScrollRect;
    private Queue<GameObject> _chatLines = new Queue<GameObject>();

	void Start () {
        _client = TwitchClient.Client;
        _client.OnMessageReceived += OnMessageRecieved;
        _client.OnMessageSent += OnMessageSent;
        _chatScrollRect = ChatContent.GetComponentInParent<ScrollRect>();
    }

    #region Messages
    private void OnMessageSent(object sender, OnMessageSentArgs e)
    {
        Debug.Log("<color=blue> MSG:  " + e.SentMessage.DisplayName + "--" + e.SentMessage.Message + "</color>");
        CreateChatLine(e.SentMessage.DisplayName, e.SentMessage.Message, e.SentMessage.ColorHex);
    }

    private void OnMessageRecieved(object sender, OnMessageReceivedArgs e)
    {
        Debug.Log("<color=blue> MSG:  " + e.ChatMessage.DisplayName + "--" + e.ChatMessage.Message + "</color>");
        
        CreateChatLine(e.ChatMessage.DisplayName, e.ChatMessage.Message, e.ChatMessage.ColorHex);
    }
    #endregion

    int i = 0;
	public void CreateChatLine(string usr, string msg, string color){
		GameObject chatLine =  Instantiate(TextLinePrefab, ChatContent.transform);
		chatLine.name = "Chat Line " +i;

		TextMeshProUGUI textMesh = chatLine.GetComponent<TextMeshProUGUI>();
        if(!string.IsNullOrEmpty(color)){
            textMesh.text = "<" + color + ">" + usr + "</color>" + " : " + msg;     
        }
        else{
            textMesh.text =  usr  + " : " + msg;     
        }
       
		i++;
        _chatLines.Enqueue(chatLine);
        
        if(_chatLines.Count > MaxNumOfMessages)
        {
            GameObject ro = _chatLines.Dequeue();
            Destroy(ro);
        }
    }

    public void SendMessage()
    {
        Debug.Log("messge???");
        if(SentMessageInputField.text != ""){
            _client.SendMessage(_client.JoinedChannels[0], SentMessageInputField.text);
            SentMessageInputField.text = "";
        }
    }
}
