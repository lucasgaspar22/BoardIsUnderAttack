using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTwoBehaviour : LevelBehaviour
{
    [SerializeField] public GameObject[] objectives;
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject indicator;
    public PointerBehaviur myPointer;
    public bool change;
    int index = 0;
    // Use this for initialization
    void Start () {
        //lastObjective = objectives[3];
        change = true;
        myPointer = pointer.GetComponent<PointerBehaviur>();
        objectives[0].SetActive(true);
        objectives[1].SetActive(false);
        objectives[2].SetActive(false);
        objectives[3].SetActive(false);
        Objective = objectives[0];
    }
	
	// Update is called once per frame
	void Update () {
        indicator.transform.position = new Vector3(Objective.transform.position.x, 5.084044f, Objective.transform.position.z);
    }

    public override void ChangeObjective()
    {
        if (change)
        {
            change = false;
            objectives[index].SetActive(false);
            index++;
            if (index >= objectives.Length)
            {

                StartCoroutine(Wait("LevelTwo-Final"));
            }
            else
            {
                Objective = objectives[index];
                Objective.SetActive(true);
                myPointer.SetPosition(Objective);
                indicator.transform.position = new Vector3(Objective.transform.position.x, 5.084044f, Objective.transform.position.z);
                if (Objective == objectives[index]) change = true;
            }
            
        }
    }

    IEnumerator Wait(string scene)
    {

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }
}
