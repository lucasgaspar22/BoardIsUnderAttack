using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehaviur : MonoBehaviour {
	[SerializeField] Vector3 topPosition;
	[SerializeField] Vector3 bottomPosition;
	[SerializeField] float upSpeed;
	[SerializeField] float pointerSpeed;
	[SerializeField] float downSpeed;
    [SerializeField] GameObject objetivePonit;
    [SerializeField]
    GameObject Indicator;
	// Use this for initialization
	void Start () {
        SetPosition(objetivePonit);
		StartCoroutine(Move(bottomPosition));
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetPosition(GameObject objective)
    {
        Transform ObjectiveTransform = objective.GetComponent<Transform>();
        Vector3 ObjectiveVector3 = new Vector3(ObjectiveTransform.position.x, bottomPosition.y, ObjectiveTransform.position.z);
        this.transform.position = ObjectiveVector3;
    }

	IEnumerator Move(Vector3 target)
	{
		while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
		{
			Vector3 direction = target.y == topPosition.y ? upSpeed * Vector3.up : downSpeed * Vector3.down;
			transform.localPosition += pointerSpeed * direction * Time.deltaTime;
			yield return null;
		}

		yield return new WaitForSeconds(0.1f);
		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;
		StartCoroutine(Move(newTarget));
	}
}
