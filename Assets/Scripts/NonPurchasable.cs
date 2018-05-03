using UnityEngine;
using System.Collections;

public class NonPurchasable : Tile {



	// Use this for initialization
	void Start () {
	
	}


	public void completeAction()
    {

    }



	
	// Update is called once per frame
	void Update () {
	
	}

    public new bool isPurchasable()
    {
        return false;
    }
}
