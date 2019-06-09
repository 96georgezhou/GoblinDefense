using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerTracking : MonoBehaviour {

	public Transform target;
	public int damage;

    private bool isDead = false;

	[Header("Attributes")]

	public float range = 15f;
	public float fireRate = 1f;
	public float fireCountdown = 0f;

	public float startHealth = 100;
	private float health;

	[Header("Unity Setup Fields")]

	public string enemyTag = "Enemy";

	public GameObject bulletPrefabs;
	public Transform firePoint;

	public Image healthBar;

	[SerializeField]
	private string layerName;

	public string towerName;

	// Use this for initialization
	void Start () {
		health = startHealth;
		InvokeRepeating("UpdateTarget",0f,0.5f);
	}

	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach(GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distanceToEnemy < shortestDistance){
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}

			if(nearestEnemy != null && shortestDistance <= range)
			{
				target = nearestEnemy.transform;
			}else{
				target = null;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null){
			return;
		}

		if(fireCountdown <= 0f){
			Shoot();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die ()
	{
		isDead = true;

		Destroy(gameObject);
	}

	void Shoot(){
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
		
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (towerName == "fire") {
			bullet.damage = StaticVariable.fireTowerDamage;
		} else if (towerName == "wind") {
			bullet.damage = StaticVariable.windTowerDamage;
		} else if (towerName == "earth") {
			bullet.damage = StaticVariable.earthTowerDamage;
		} else if (towerName == "water") {
			bullet.damage = StaticVariable.waterTowerDamage;
		} else if (towerName == "lightning") {
			bullet.damage = StaticVariable.lightntowerDamage;
		} else {
			bullet.damage = 50;
		}


		Debug.Log("Damage: " + bullet.damage + " and " + StaticVariable.fireTowerDamage);
		
		// bullet.damage = tempDamage;
		bullet.towerName = this.towerName;
		
		

		if(bullet != null){
			bullet.Seek(target);
		}
	}

	void OnDrawGizmosSelected (){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
