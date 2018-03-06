using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationsBehaviour : MonoBehaviour {

    [SerializeField]    int AnimationTime;
    [SerializeField]    string myScene;
    public int t;

	// Use this for initialization
	void Start () {
        //player = GetComponent<PlayerBehaviour>();
        Debug.Log(t);
        StartCoroutine(WaitAnimation(AnimationTime));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(myScene);
    }

    IEnumerator WaitAnimation(int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(myScene);
    }
}
