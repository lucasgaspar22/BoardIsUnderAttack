using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBehaviour : MonoBehaviour {
	// Use this for initialization
	[SerializeField] public PlayerBehaviour player;
	int timerObjective;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player")
			player.Load();
	}
}
