using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadialProgressBarBehaviour : MonoBehaviour {
	public GameObject LoadingBar;
	public GameObject TextIndicator;
	public GameObject Status;
	[SerializeField] public float currentProgress;
	[SerializeField] private int speed;				
	[SerializeField] private float barRefreshRate;
	[SerializeField] private PlayerBehaviour behave;
	
	public void myStart()
	{
		currentProgress = 0;
		TextIndicator.GetComponent<Text> ().text = "0%";
		LoadingBar.GetComponent<Image> ().fillAmount = 0;
		StartCoroutine (progressLoad());
	}

	IEnumerator progressLoad(){
		while (true) {
			yield return new WaitForSeconds(barRefreshRate);
			if (currentProgress < 100) {
				currentProgress += speed;
				if (currentProgress > 100)
					currentProgress = 100;
				TextIndicator.GetComponent<Text> ().text = ((int)currentProgress).ToString () + "%";
				Status.SetActive (true);
			} else {
				Status.SetActive (false);
				TextIndicator.GetComponent<Text> ().text = "Done";
				behave.WaitProgressBar ();
				StopCoroutine ("progressLoad");
			}
			LoadingBar.GetComponent<Image>().fillAmount = currentProgress / 100;
		}

	}
}
