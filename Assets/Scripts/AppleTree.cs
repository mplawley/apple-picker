/*
 * This script manages the apple picker game
 * 
 */

using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour
{
	#region Fields
	public GameObject applePrefab;
	public float appleTreeSpeed = 1f;
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirections = .1f;
	public float secondsBetweenAppleDrops = 1f;
	#endregion

	#region Methods
	void Start()
	{
		//Drop an apple every second
		InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);	
	}

	void Update()
	{
		//Basic movement
		Vector3 pos = transform.position;
		pos.x += appleTreeSpeed * Time.deltaTime;
		transform.position = pos;

		//Changing direction
		if (pos.x < -leftAndRightEdge)
		{
			//Move right
			appleTreeSpeed = Mathf.Abs(appleTreeSpeed);
		}
		else if (pos.x > leftAndRightEdge)
		{
			//Move left
			appleTreeSpeed = -Mathf.Abs(appleTreeSpeed);
		}
	}

	//Called 50 times per second regardless of machine
	void FixedUpdate()
	{
		//Changing direction randomly. Not in Update() because then, faster machines would make the tree change direction more often.
		if (Random.value < chanceToChangeDirections)
		{
			//Change direction
			appleTreeSpeed *= -1;
		}
	}

	void DropApple()
	{
		GameObject apple = NewObjectPoolerScript.current.GetPooledObject();
		if (apple == null)
		{
			return;
		}
		apple.transform.position = transform.position;
		apple.transform.rotation = transform.rotation;
		apple.SetActive(true);
	}

	#endregion
}
