using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StatusPanel : MonoBehaviour
{
    public static StatusPanel instance;

    [SerializeField] private GameObject scoreBar;
    [SerializeField] private GameObject moneyBar;
    [SerializeField] private GameObject lifeBar;

    [SerializeField] private int intialMoney;
    [SerializeField] private int initialLife;

    private int score;
    private int money;
    private int life;

    // Use this for initialization
    void Start()
    {
        // initialized this for invokation
        instance = this;

        score = 0;
        money = intialMoney;
        life = initialLife;
    }

    private void Update()
    {
        scoreBar.GetComponent<Text>().text = "Score: " + score;
        moneyBar.GetComponent<Text>().text = "Money: " + money;
        lifeBar.GetComponent<Text>().text = "Life: " + life;
    }

//    public IEnumerator PointAccum()
//    {    
//        while (true)
//        {
//            ++money;
//            yield return new WaitForSeconds(1.0f);
//            moneyBar.GetComponent<Text>().text = "score: " + money;
//        }
//    }

    public void AddMoney(int _amount)
    {
        money += _amount;
    }

    public int getScore()
    {
        return this.score;
    }

    public bool IsAlive()
    {
        if (0 < life)
        {
            return true;
        }

        return false;
    }

    public void DecreaseLife()
    {
        --life;
        lifeBar.GetComponent<Text>().text = "Life: " + life;
    }

    public bool DecreaseMoney(int _money)
    {
        if (_money <= this.money)
        {
            this.money -= _money;
            return true;
        }

        return false;
    }

    public void AddScore(int _score)
    {
        this.score += _score;
    }
}