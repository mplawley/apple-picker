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
		//De-activate me if I'm off-screen
		if (transform.position.y < bottomY)
		{
			this.gameObject.SetActive(false);
			//Get a reference to the ApplePicker component of the Main Camera
			ApplePicker applePickerScript = Camera.main.GetComponent<ApplePicker>();

			//Call the AppleDestroyed() method of the applePickerScript
			applePickerScript.AppleDestroyed();
		}
	}
	#endregion
}
