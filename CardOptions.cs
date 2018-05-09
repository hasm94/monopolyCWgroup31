using UnityEngine;
using System.Collections;

public class CardOptions : MonoBehaviour {

	private Dropdown dropDown;
	private bool showCardOptions;

	// Use this for initialization
	void Start () {
	
		cardOptionsPanel = GameObject.FindObjectOfType<CardOptions> ();

		dropDown = GameObject.FindObjectOfType<Dropdown> ();

	}

	public void SelectedAction(int actionIndex)
	{

		if (actionIndex == 1) {
			Debug.Log ("You selected the first option");
		} else {
			Debug.Log ("You selected the second option");
		}

		//TODO: Variable in Monopoly called showCantPayActions = true 
		//theGameStat.showCantPayActions = false;
		//GameObject.GetComponent<CantPayPanel> ().enabled = false;
	}

	void showHidePanel() {

		if (showCardOptions) {
			cardOptionsPanel.gameObject.SetActive (true);
		} else {
			cardOptionsPanel.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		showHidePanel ();
	}
}
