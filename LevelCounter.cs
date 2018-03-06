using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCounter : MonoBehaviour {

    [SerializeField] string nextLevel;
	// Use this for initialization
	void Start () {
        StartCoroutine(LevelIncrement(nextLevel));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator LevelIncrement(string nextLevel)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(nextLevel);
    }
}
