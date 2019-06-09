using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    public void StarGame()
    {
//        StartCoroutine(GenScript.instance.IeStartWave());
//        StartCoroutine(StatusPanel.instance.PointAccum());
        CanvasGameManager.instance.StartWave();
    }
}
