/*
 * This script implements a generic object pooler. It can be used 
 * for anything from bullets to platforms to enemy spawns to powerups 
 * to whatever else. It builds off the principle that searching a list is faster
 * than maintaining, for instance, two lists (active/inactive) objects.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewObjectPoolerScript : MonoBehaviour
{
	#region Fields
	public static NewObjectPoolerScript current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = true;
	List<GameObject> pooledObjects;
	#endregion

	#region Methods

	void Awake()
	{
		current = this;
	}

	void Start()
	{
		pooledObjects = new List<GameObject>();

		for (int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				//Don't activate the object here. Just return to whatever called me and let the object
				//that requests the pooledObject to activate it. This will circumvent problems that can arise
				//when activating the object before placing it where we want it.
				return pooledObjects[i];
			}
		}

		//Dynamically resize pool. Warning: Can grow but won't shrink.
		if (willGrow)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add(obj);
			return obj;
		}

		//If out of objects and not allowed to create any more new ones...
		return null;
	}
	#endregion
}
