using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour {

	public Transform prefabLoc;
	public GameObject prefab;
    

	private int count = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (count <= 3000) {
			if (count % 300 == 0) {
				Instantiate (prefab, prefabLoc, true);
                // Debug.Log(prefabLoc.position);
			}

			count++;
		}


	}

}
