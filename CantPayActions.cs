using UnityEngine;
using System.Collections;

public class CantPayActions : MonoBehaviour {

	//private Monopoly theGameState;
	//public GameObject CantPayPanel;
	private Dropdown dropDown;
	private bool showCantPay;

	// Use this for initialization
	void Start () {
	
		cantPayPanel = GameObject.FindObjectOfType<cantPayPanel> ();

		dropDown = GameObject.FindObjectOfType<Dropdown> ();

	}

	public void SelectedAction(int actionIndex)
	{

		if (actionIndex == 1) {
			Debug.Log ("You selected to mortage your property");
		} else {
			Debug.Log ("You selected to sell your property");
		}

		//TODO: Variable in Monopoly called showCantPayActions = true 
		//theGameStat.showCantPayActions = false;
		//GameObject.GetComponent<CantPayPanel> ().enabled = false;
	}

	void showHidePanel() {

		if (showCantPayActions) {
			CantPayPanel.gameObject.SetActive (true);
		} else {
			CantPayPanel.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		showHidePanel ();
	}
}
