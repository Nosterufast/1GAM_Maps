using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	public InputController inputController;
	public CameraSizer cameraSizer;
	private Vector3 playerDirection = Vector3.zero;
	private Vector3 temp = Vector3.zero;
	private float moveSpeed = 1.0f;
	private float minMoveSpeed = 0.0f;
	private float maxMoveSpeed = 1.0f;
	private float timeToMaxSpeed = .5f;
	private float timeMoveButtonHeld = 1.0f;
	private Vector2 playerPos;
	private float translateX = 0.0f;
	private float translateY = 0.0f;
	private Vector3 startPos, endPos;

	//distance to lerp character after triggerig transition collider
	private float translateXDistance = 48.0f;
	private float translateYDistance = 36.0f;
	private bool lerpPlayer = false;
	private float currentLerpTime = 0.0f;
	private float lerpTime = 1.0f;

	public bool playerActive = false;

	private Vector3 prevPlayerPos, nextPlayerPos;
	public bool colliding = false;
	private string transitionCollider = string.Empty;

	//up and down get summed, and left and right get summed to calculate directional vector
	private float upValue, rightValue, downValue, leftValue;

	//used to mark the time when a movement button is first pressed
	private float startMovementPress;
	public bool playerIsMoving = false;

	void Start () 
	{
		prevPlayerPos = transform.position;
		playerActive = true;
	}
	
	void Update () 
	{
		//assign values to up, right, down, left float variables if the player is active
		if(playerActive)
		{
			upValue = (inputController.playerMovingUp == true) ? 1.0f : 0.0f;
			rightValue = (inputController.playerMovingRight == true) ? 1.0f : 0.0f;
			downValue = (inputController.playerMovingDown == true) ? -1.0f : 0.0f;
			leftValue = (inputController.playerMovingLeft == true) ? -1.0f : 0.0f;
		}

		//sum values of each axis to determine actual direction
		playerDirection.x = leftValue + rightValue;
		playerDirection.y = upValue + downValue;

		//player is moving
		if(playerDirection.x != 0 || playerDirection.y != 0)
		{
			timeMoveButtonHeld += Time.deltaTime;
			playerIsMoving = true;
		}
		else
		{
			timeMoveButtonHeld = 1.0f;
			playerIsMoving = false;
		}

		//clamp the max time used for holding down move buttons
		timeMoveButtonHeld = Mathf.Clamp(timeMoveButtonHeld, 0.0f, timeToMaxSpeed);
		nextPlayerPos = (playerDirection * ((int)((timeMoveButtonHeld / timeToMaxSpeed) * maxMoveSpeed)) * moveSpeed);
//		transform.Translate((playerDirection.normalized * Time.deltaTime * .5f));
		if(lerpPlayer == true)
		{
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime)
			{
				currentLerpTime = lerpTime;
			}
			
			float percent = currentLerpTime / lerpTime;
			percent = percent*percent*percent * (percent * (6f*percent - 15f) + 10f);
			transform.position = Vector3.Lerp(startPos, endPos, percent);
			
			//reset info if lerp is complete
			if(currentLerpTime == lerpTime)
			{
				lerpPlayer = false;
				translateX = translateY = 0.0f;
				currentLerpTime = 0.0f;
			}
		}
	}//end Update

	public void transitionalLerpPlayer(string transition)
	{
		//TODO disable trans colliders too
		switch(transition)
		{
		case "TransColliderNorth":
			translateX = 0f;
			translateY = translateYDistance;
			break;
		case "TransColliderEast":
			translateX = translateXDistance;
			translateY = 0f;
			break;
		case "TransColliderSouth":
			translateX = 0f;
			translateY = -translateYDistance;
			break;
		case "TransColliderWest":
			translateX = -translateXDistance;
			translateY = 0f;
			break;
		}
		lerpPlayer = true;
		startPos = transform.position;
		endPos = startPos + new Vector3(translateX, translateY, 0);
	}
	
	void FixedUpdate()
	{
		if(playerActive == true)
			transform.Translate(nextPlayerPos);
		else
		{
			//TODO lerp the player in the correct direction based on transition collider triggered
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		cameraSizer.animateCamera(collision.gameObject.name);
		transitionalLerpPlayer(collision.gameObject.name);
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		colliding = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
//		print("collision");
	}

//	void LateUpdate()
//	{
//		if(colliding == false)
//		{
//			transform.position += nextPlayerPos;
//			prevPlayerPos = transform.position;
//		}
//		else
//		{
//			transform.position = prevPlayerPos;
//			colliding = false;
//		}
//		print("current pos" + prevPlayerPos);
			
//	}
}//end PlayerController class
