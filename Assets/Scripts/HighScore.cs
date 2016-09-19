/*
 * This script keeps track of the player's high score
 * 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
	#region Fields
	static public int score = 1000;
	#endregion

	#region Methods
	void Awake()
	{
		//If the ApplePickerHighScore already exists, read it
		if (PlayerPrefs.HasKey("ApplePickerHighScore"))
		{
			score = PlayerPrefs.GetInt("ApplePickerHighScore");
		}

		//Assign the high score to ApplePickerHighScore
		PlayerPrefs.SetInt("ApplePickerHighScore", score);
	}
	// Update is called once per frame
	void Update()
	{
		Text gt = this.GetComponent<Text>();
		gt.text = "High Score: " + score;

		//Update ApplePickerHighScore in PlayerPrefs if necessary
		if (score > PlayerPrefs.GetInt("ApplePickerHighScore"))
		{
			PlayerPrefs.SetInt("ApplePickerHighScore", score);
		}
	}
	#endregion
}
