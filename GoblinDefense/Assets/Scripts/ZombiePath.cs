using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePath : MonoBehaviour {

    private GameObject victim;
	private NavMeshAgent navComponent;

	// Use this for initialization
	void Start () {
        this.victim = GameObject.Find("Victim"); 
        this.navComponent = this.transform.GetComponent<NavMeshAgent> ();
        
	}
	
	// Update is called once per frame
	void Update () {
      	if (victim) {
			this.navComponent.SetDestination (this.victim.transform.position);
		}
	}
}
