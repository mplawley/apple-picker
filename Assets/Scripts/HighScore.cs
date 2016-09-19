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
		
	// Update is called once per frame
	void Update()
	{
		Text gt = this.GetComponent<Text>();
		gt.text = "High Score: " + score;
	}
	#endregion
}
