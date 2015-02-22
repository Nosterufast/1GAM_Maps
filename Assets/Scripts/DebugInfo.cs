using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugInfo : MonoBehaviour {
	public Text screenWidth;
	public Text other1;
	public Text other2;

	public SpriteRenderer backgroundSpriteRenderer;
	private float bgSpriteWidth, bgSpriteHeight;

	// Use this for initialization
	void Start () 
	{
		bgSpriteWidth = backgroundSpriteRenderer.sprite.bounds.size.x;
		bgSpriteHeight = backgroundSpriteRenderer.sprite.bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		screenWidth.text = "Screen WxH: " + Screen.width.ToString() + "x" + Screen.height.ToString();
		other1.text = "bgsprite WxH: " + bgSpriteWidth + "x" + bgSpriteHeight;
	}
}
