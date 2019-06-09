using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public Transform target;

	public string enemyName;

    public float startHealth = 100;
	private float health;

    [Header("Unity Stuff")]
	public Image healthBar;

    private bool isDead = false;

    [Header("Attributes")]

	public float range = 15f;
	public float fireRate = 1f;
	public float fireCountdown = 1f;

    [Header("Unity Setup Fields")]

	public string enemyTag = "Tower";

	public GameObject bulletPrefabs;
	public Transform firePoint;

    // Use this for initialization
    void Start()
    {
        health = startHealth;
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
			return;
		}
//        if(fireCountdown <= 0f && this.GetComponent<Rigidbody2D>().IsSleeping()){
	    if(fireCountdown <= 0f && !AstarPath.instance.isValidPath){
			Shoot();
            fireCountdown = 1f;
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
		StatusPanel.instance.AddScore(10);
		StatusPanel.instance.AddMoney(1);

		Destroy(gameObject);
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
    void Shoot(){
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
		
		BulletKillTower bullet = bulletGO.GetComponent<BulletKillTower>();

		if(bullet != null){
			bullet.Seek(target);
		}
	}

	void OnDrawGizmosSelected (){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
