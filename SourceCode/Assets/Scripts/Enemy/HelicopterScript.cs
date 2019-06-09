using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterScript : MonoBehaviour {

	private float previous;
	private SpriteRenderer renderer;
	public Sprite left;
	public Sprite right;
	// Use this for initialization
	void Start()
	{
		this.previous = this.transform.position.x;
		this.renderer = this.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		float direction = (this.transform.position.x - this.previous);
		if (direction > 0.0)
		{
			this.renderer.sprite = this.right;

		}
		else if (direction < 0.0)
		{
			this.renderer.sprite = this.left;

		}
		else
		{

			//            Debug.Log("What happened????" + direction);
		}
		this.previous = this.transform.position.x;
	}
}
