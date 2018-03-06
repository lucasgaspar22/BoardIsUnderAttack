using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelBehaviour : MonoBehaviour {
    public GameObject Objective;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void ChangeObjective();
}
