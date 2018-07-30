using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour {

    private bool showStats = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleStats()
    {    
        if (gameObject.activeSelf != showStats)
            showStats = gameObject.activeSelf; 
        showStats = !showStats;
        gameObject.SetActive(showStats);
    }

    public void forceOpenStats()
    {
        gameObject.SetActive(true);
    }

    public void revert()
    {
        gameObject.SetActive(showStats);
    }
}
