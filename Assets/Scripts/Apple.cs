/*
 * This script kills apple clones once they are comfortably off-screen
 * 
 */

using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour
{
	#region Fields
	public static float bottomY = -20f;
	#endregion

	#region Methods
	void Update()
	{
		//Destroy me if I'm off-screen
		if (transform.position.y < bottomY)
		{
			Destroy(this.gameObject);
		}

		//Get a reference to the ApplePicker component of the Main Camera
		ApplePicker applePickerScript = Camera.main.GetComponent<ApplePicker>();

		//Call the AppleDestroyed() method of the applePickerScript
		applePickerScript.AppleDestroyed();
	}
	#endregion
}
