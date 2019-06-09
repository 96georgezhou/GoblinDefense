using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    public static Victim instance;

    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        StatusPanel.instance.DecreaseLife();
        if (!StatusPanel.instance.IsAlive())
        {
            StaticVariable.score = StatusPanel.instance.getScore();
            CanvasGameManager.instance.GameOver();
        }
        
        Debug.Log("*********************************************");
        Debug.Log(col.gameObject);
        Destroy(col.gameObject);
    }
}