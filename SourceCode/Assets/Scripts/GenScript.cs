using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenScript : MonoBehaviour
{
    public static GenScript instance;

    [SerializeField] private GameObject soldier;
    [SerializeField] private GameObject tank;
    [SerializeField] private GameObject helicopter;

    private int soldierHealth = 50;
    private int tankHealth = 100;
    private int helicopterHealth = 150;


    public int count = 0;
    private float time = 1f;
    private GameObject genPoint;

    [SerializeField] private string layerName;

    // Use this for initialization
    void Start()
    {
        this.genPoint = GameObject.Find("GenPoint");
        instance = this;
    }

    public void StartWave()
    {
        Debug.Log("StartWave() is  called");
        StartCoroutine(IeStartWave());
    }

    public IEnumerator IeStartWave()
    {
        // x3 times faster every 20 soldiers
//        for (float duration = 1.0f; duration>0; duration= duration/3 +0.05f)
        for (float duration = 1.0f; duration>0; )
        {
            for (int i = 0; i < 20; ++i)
            {
                GameObject current = Instantiate(this.soldier, this.genPoint.transform, true);
                current.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
                Enemy currentScript = current.GetComponent<Enemy>();
                currentScript.startHealth = this.soldierHealth;
				currentScript.enemyName = "soldier";
                yield return new WaitForSeconds(duration);
            }

            for (int i = 0; i < 20; ++i)
            {
                GameObject current = Instantiate(this.tank, this.genPoint.transform, true);
                current.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
                Enemy currentScript = current.GetComponent<Enemy>();
                currentScript.startHealth = this.tankHealth;
				currentScript.enemyName = "tank";
                yield return new WaitForSeconds(duration);
            }

            for (int i = 0; i < 20; ++i)
            {
                GameObject current = Instantiate(this.helicopter, this.genPoint.transform, true);
                current.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
                Enemy currentScript = current.GetComponent<Enemy>();
                currentScript.startHealth = this.helicopterHealth;
				currentScript.enemyName = "helicopter";
                yield return new WaitForSeconds(duration);
            }

            this.soldierHealth *= 2;
            this.tankHealth *= 2;
            this.helicopterHealth *= 2;

          

        }
    }

//    // Update is called once per frame
//    void Update()
//    {
//        this.time -= 1 * Time.deltaTime;
//        if (this.count < 10 && this.time <= 0)
//        {
//            Instantiate(enemy, this.genPoint.transform, true);
//            enemy.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
//            this.count++;
//            this.time = 1f;
//        }
//    }
}