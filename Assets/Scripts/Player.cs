using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float playerMoveOffset = .5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.position = new Vector3(transform.position.x,
			                                 transform.position.y + playerMoveOffset,
			                                 transform.position.z);
		}
	if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			transform.position = new Vector3(transform.position.x,
			                                 transform.position.y - playerMoveOffset,
			                                 transform.position.z);
		}
	if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.position = new Vector3(transform.position.x - playerMoveOffset,
			                                 transform.position.y,
			                                 transform.position.z);
		}
	if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.position = new Vector3(transform.position.x + playerMoveOffset,
			                                 transform.position.y,
			                                 transform.position.z);
		}
	}
}
