using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneBehaviour : LevelBehaviour {

    [SerializeField] GameObject GND;
    [SerializeField] GameObject Pin13;
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject indicator;
    public  PointerBehaviur myPointer;
    public bool change;
    // Use this for initialization
    void Start()
    {
        change = true;
        myPointer = pointer.GetComponent<PointerBehaviur>();
		GND.SetActive(true);
        Pin13.SetActive(false);
        Objective = GND;
    }

    // Update is called once per frame
    void Update()
    {
        indicator.transform.position = new Vector3(Objective.transform.position.x, 6.15f, Objective.transform.position.z);

    }

    public override void ChangeObjective()
    {
        if (change) {
            change = false;
			if (Objective.tag == "GND") {
				Objective = Pin13;
				myPointer.SetPosition (Objective);
				GND.SetActive (false);
				Pin13.SetActive (true);
				change = true;
			} else if (Objective.tag == "Pin13") {
				StartCoroutine (Wait ("LevelOneEnd"));
			}
        }
    }
	IEnumerator Wait(string scene){
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene (scene);
	}
}
