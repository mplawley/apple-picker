/*
 * This script dictates basket behaviors
 * 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
	#region Fields
	public Text scoreText;
	public int pointsForCatchingApple = 100;
	#endregion

	#region Methods

	void Start()
	{
		//Find a reference to the Score Counter GameObject
		GameObject scoreGameObject = GameObject.Find("ScoreCounter");

		//Get the Text component of that GameObject
		scoreText = scoreGameObject.GetComponent<Text>();

		//Set the starting number of points to 0
		scoreText.text = "0";
	}

	void Update()
	{
		//Get the current screen position of the mouse from Input
		Vector3 mousePos2D = Input.mousePosition;

		//The Camera's z position sets how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z;

		//Convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

		//Move the x position of this Basket to the x position of the mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter(Collision col)
	{
		//Find out what hit the basket
		GameObject collidedWith = col.gameObject;
		if (collidedWith.tag == "Apple")
		{
			collidedWith.SetActive(false);
		}

		//Parse the text of the scoreGT into an int
		int score = int.Parse(scoreText.text);

		//Add points for catching the apple
		score += pointsForCatchingApple;

		//Convert the score back to a string and display it
		scoreText.text = score.ToString();

		//Track the high score
		if (score > HighScore.score)
		{
			HighScore.score = score;
		}
	}
	#endregion
}
