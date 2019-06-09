using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameManager : MonoBehaviour {

    public static CanvasGameManager instance;

	// Use this for initialization
	void Start () {
        instance = this;
        StartCoroutine(RefreshPath());
		
	}

    public void GameOver()
    {
	    Debug.Log("GameOver called");
	    SceneManager.LoadScene("GameOver");
    }

    public void StartWave()
    {
	    // Start the wave and timer
	    StartCoroutine(GenScript.instance.IeStartWave());
//	    StartCoroutine(StatusPanel.instance.PointAccum());
    }

    private IEnumerator RefreshPath()
    {
	    while (true)
	    {
		    if (AstarPath.instance != null)
			    AstarPath.instance.Scan();
		    yield return new WaitForSeconds(0.5f);
	    }
    }
}
