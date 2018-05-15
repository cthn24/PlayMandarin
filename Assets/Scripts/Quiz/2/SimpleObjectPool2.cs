﻿
using UnityEngine;
using System.Collections.Generic;

// A very simple object pooling class
public class SimpleObjectPool2 : MonoBehaviour
{
	// the prefab that this object pool returns instances of
	public GameObject prefab;
	// collection of currently inactive instances of the prefab
	private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

	// Returns an instance of the prefab
	public GameObject GetObject() 
	{
		GameObject spawnedGameObject;

		// if there is an inactive instance of the prefab ready to return, return that
		if (inactiveInstances.Count > 0) 
		{
			// remove the instance from teh collection of inactive instances
			spawnedGameObject = inactiveInstances.Pop();
		}
		// otherwise, create a new instance
		else 
		{
			spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

			// add the PooledObject component to the prefab so we know it came from this pool
			PooledObject2 pooledObject2 = spawnedGameObject.AddComponent<PooledObject2>();
			pooledObject2.pool = this;
		}

		// enable the instance
		spawnedGameObject.SetActive(true);

		// return a reference to the instance
		return spawnedGameObject;
	}

	// Return an instance of the prefab to the pool
	public void ReturnObject(GameObject toReturn) 
	{
		PooledObject2 pooledObject2 = toReturn.GetComponent<PooledObject2>();

		// if the instance came from this pool, return it to the pool
		if(pooledObject2 != null && pooledObject2.pool == this)
		{
			// disable the instance
			toReturn.SetActive(false);

			// add the instance to the collection of inactive instances
			inactiveInstances.Push(toReturn);
		}
		// otherwise, just destroy it
		else
		{
			Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from! Destroying.");
			Destroy(toReturn);
		}
	}
}

// a component that simply identifies the pool that a GameObject came from
public class PooledObject2 : MonoBehaviour
{
	public SimpleObjectPool2 pool;
}
