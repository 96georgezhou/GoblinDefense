using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public float speed = 70f;

	public int damage = 50;
	public string towerName; 

	public void Seek(Transform _target){
		target = _target;
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null){
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distanceThisFrame){
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		 
	}

	void HitTarget(){
		Damage(target);
		Destroy(gameObject);
	}

	void Damage (Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		int currentDamage = this.damage;
		if (this.towerName == "fire") {
			// more damage on soldier 
			if (e.enemyName == "soldier") {
				currentDamage +=  (int) (this.damage * 0.2);
			}
		} else if (this.towerName == "wind") {
			// nothing happens
		} else if (this.towerName == "earth") {
			if (e.enemyName == "soldier") {
				currentDamage -= (int) (this.damage * 0.5);
				Pathfinding.AILerp temp = e.GetComponentsInParent<Pathfinding.AILerp> ()[0];
				temp.speed = temp.speed/2 + 20;
			}
		} else if (this.towerName == "water") {
			if (e.enemyName == "tank" || e.enemyName == "helicopter") {
				currentDamage -= (int) (this.damage * 0.5);
				Pathfinding.AILerp temp = e.GetComponentsInParent<Pathfinding.AILerp> ()[0];
				temp.speed = temp.speed/2 + 20;
			}
		} else if (this.towerName == "lightning") {
			if (e.enemyName == "helicopter") {
				currentDamage +=  (int) (this.damage * 0.2);
			}
		}

		if (e != null)
		{
            // apply variable formulas 
            e.TakeDamage(currentDamage);
		}
	}
}
