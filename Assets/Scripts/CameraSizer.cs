using UnityEngine;
using System.Collections;

public class CameraSizer : MonoBehaviour {

	public PlayerController playerController;
	public SpriteRenderer backgroundSpriteRenderer;
	private float bgSpriteWidth = 384;
	private float bgSpriteHeight = 208;
	private Vector3 camPos, startPos, endPos;
	public Transform playerTransform;
	public TransitionColliderManager transitionColliderManager;

	private float translateX, translateY;
	private bool translateCamera = false;
	private float currentLerpTime = 0.0f;
	private float lerpTime = 1.0f;

	void Start()
	{
		//Camera.main.orthographicSize = Screen.height / (2*3);
		camPos = Camera.main.transform.position;
		Camera.main.transform.position = new Vector3(camPos.x + bgSpriteWidth/2.0f,
		                                             camPos.y - bgSpriteHeight/2.0f,
		                                             camPos.z);
		camPos = Camera.main.transform.position;
		//this weird offset makes the camera upscale pixels accurately
		//the 3.9f shift is due to the screen needing a bit extra so that the camera sits
		//squarely on the screen with a black bar above
		Camera.main.transform.position = new Vector3(Mathf.Round(camPos.x), Mathf.Round(camPos.y), camPos.z) +
																								 new Vector3(-0.1f,3.9f,0f);
	}

	public void animateCamera(string transition)
	{
		switch(transition)
		{
		case "TransColliderNorth":
			translateX = 0f;
			translateY = bgSpriteHeight;
			break;
		case "TransColliderEast":
			translateX = bgSpriteWidth;
			translateY = 0f;
			break;
		case "TransColliderSouth":
			translateX = 0f;
			translateY = -bgSpriteHeight;
			break;
		case "TransColliderWest":
			translateX = -bgSpriteWidth;
			translateY = 0f;
			break;
		}
		playerController.playerActive = false;
		transitionColliderManager.disableTransitionColliders();
		startPos = transform.position;
		endPos = startPos + new Vector3(translateX, translateY, 0);
		translateCamera = true;

	}

	void Update () 
	{
		//lerp camera
		if(translateCamera == true)
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
				translateCamera = false;
				translateX = translateY = 0.0f;
				currentLerpTime = 0.0f;
				transitionColliderManager.enableTransitionColliders();
				playerController.playerActive = true;
				
			}
		}

	
//		Camera.main.orthographicSize = 216.0f / 16.0f / 2.0f;
//		Camera.main.orthographicSize = Screen.height / (2*3);
	}
	
}
