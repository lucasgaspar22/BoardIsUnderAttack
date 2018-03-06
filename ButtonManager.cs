using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

    void Start()
    {
        Cursor.visible = true; 
    }
	// Use this for initialization
    public void CallScene(string scene)
    {
        
        SceneManager.LoadScene(scene);
    }
}
