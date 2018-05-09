using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PurchasableActions : MonoBehaviour {

	//public GameObject purchasablePanel;
	private Dropdown dropDown;

	void Start()
	{

		purchasablePanel = GameObject.FindObjectOfType<PurchasablePanel> ();

		dropDown = GameObject.FindObjectOfType<Dropdown> ();

	}

	public void SelectedAction(int actionIndex)
	{

			if (actionIndex == 1) {
				Debug.Log ("You slected to buy the property");
			} else {
				Debug.Log ("You selected to give property to auction");
			}

		GameObject.GetComponent<PurchasablePanel> ().enabled = false;
	}

	public void showHidePanel() {

		if (showPurchasableActions) {
			purchasablePanel.gameObject.SetActive (true);
		} else {
			purchasablePanel.gameObject.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}