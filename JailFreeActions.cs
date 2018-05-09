using UnityEngine;
using System.Collections;

public class JailFreeAction : MonoBehaviour {

	//private Monopoly theGameState;
	//public GameObject jailFreePanel;
	private Dropdown dropDown;
	private bool showJailFreeActions;

	// Use this for initialization
	void Start () {

		jailFreePanel = GameObject.FindObjectOfType<jailFreePanel> ();

		dropDown = GameObject.FindObjectOfType<Dropdown> ();
	
	}

	public void SelectedAction(int actionIndex)
	{

		if (actionIndex == 1) {
			Debug.Log ("You selected to use your get out of jail free card");
		} else {
			Debug.Log ("You selected to stay in Jail");
		}

		//TODO: Variable in Monopoly called showPurchasableActions = true 
		//theGameStat.showPurchasableActions = false;
		//GameObject.GetComponent<PurchasablePanel> ().enabled = false;
	}

    void showHidePanel() {

		if (showJailFreeActions) {
			jailFreePanel.gameObject.SetActive (true);
		} else {
			jailFreePanel.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		showHidePanel ();
	}
}
