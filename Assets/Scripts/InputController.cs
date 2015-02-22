using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour 
{
	//player cardinal directions
	public bool playerMovingUp;
	public bool playerMovingRight;
	public bool playerMovingDown;
	public bool playerMovingLeft;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		//check for keydowns
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			playerMovingUp = true;
		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			playerMovingRight = true;
		if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			playerMovingDown = true;
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			playerMovingLeft = true;

		//check for keyups
		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
			playerMovingUp = false;
		if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
			playerMovingRight = false;
		if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
			playerMovingDown = false;
		if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
			playerMovingLeft = false;
	}
}//end InputController class
