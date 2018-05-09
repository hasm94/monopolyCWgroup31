using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeParking : NonPurchasable
{

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public FreeParking(string n) : base(n)
    {

    }

    public void CompleteAction(Player p)
    {
        Debug.Log("Player has received the free parking fines");

    }

}
