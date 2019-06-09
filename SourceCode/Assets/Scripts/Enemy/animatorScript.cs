using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorScript : MonoBehaviour {
	private float previous;
	private Animator animator;
	public RuntimeAnimatorController left;
	public RuntimeAnimatorController right;
	// Use this for initialization
	void Start () {
		this.previous = this.transform.position.x; 
		this.animator = this.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		float direction = (this.transform.position.x - this.previous);
		if (direction > 0.0) {
			this.animator.runtimeAnimatorController = right;

		} else if (direction < 0.0) {
			this.animator.runtimeAnimatorController = left;

		} else {
		
//			Debug.Log ("What happened????" + direction);
		}

		this.previous = this.transform.position.x;

	}
}
