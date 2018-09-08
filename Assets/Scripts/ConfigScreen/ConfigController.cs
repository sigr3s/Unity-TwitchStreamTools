using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfigController : MonoBehaviour {

	public InputField ChannelName;
	public string NextScene;

	public void ValidateAndSave(){
		if(!string.IsNullOrEmpty(ChannelName.text)){
			PlayerPrefs.SetString("channelName", ChannelName.text);
			SceneManager.LoadScene(NextScene);
		}
		else{
			// Fancy thing here to show that user has done somtthing badddd
		}
	}
}
