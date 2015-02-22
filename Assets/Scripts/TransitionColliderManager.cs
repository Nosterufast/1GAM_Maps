using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransitionColliderManager : MonoBehaviour {

	public GameObject[] transitionColliderGameObjects;
	private List<BoxCollider2D> transitionColliderList;

	// Use this for initialization
	void Start () 
	{
		//get all transition colliders, put them in the BoxCollider2D list
		transitionColliderList = new List<BoxCollider2D>();
		foreach(GameObject coll in transitionColliderGameObjects)
		{
			BoxCollider2D[] tempColliderArray = coll.GetComponentsInChildren<BoxCollider2D>();
			foreach (BoxCollider2D boxColl in tempColliderArray)
			{
				transitionColliderList.Add(boxColl);
			}
		}
	}

	public void enableTransitionColliders()
	{
		foreach(BoxCollider2D collider in transitionColliderList)
		{
			collider.enabled = true;
		}
	}

	public void disableTransitionColliders()
	{
		foreach(BoxCollider2D collider in transitionColliderList)
		{
			collider.enabled = false;
		}
	}
}
