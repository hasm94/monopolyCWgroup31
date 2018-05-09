using UnityEngine;
using System.Collections;

public class OwnedPropertyActions : MonoBehaviour {

	//public GameObject CantPayPanel;
	private Dropdown dropDown;
	private bool showCantPay;

	// Use this for initialization
	void Start () {
	
		ownedPropertyPanel = GameObject.FindObjectOfType<cantPayPanel> ();

		dropDown = GameObject.FindObjectOfType<Dropdown> ();
	}

	public void SelectedAction(int actionIndex)
	{

		if (actionIndex == 1) {
			Debug.Log ("You selected to build a house");
		} else {
			Debug.Log ("You selected to sell the house");
		}

		//TODO: Variable in Monopoly called showCantPayActions = true 
		//theGameStat.showCantPayActions = false;
		//GameObject.GetComponent<CantPayPanel> ().enabled = false;
	}

	void showHidePanel() {

		if (showOwnedPropertyActions) {
			ownedPropertyPanel.gameObject.SetActive (true);
		} else {
			ownedPropertyPanel.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		showHidePanel ();
	}
}
