using UnityEngine;
using System;
using System.Collections;

public class Utility : Purchasable {

	// Use this for initialization
	new void Start ()
    {
        
	}

	// Update is called once per frame
	void Update () {

	}

    public Utility(String n, int c, int[] r, Street st) : base(n, c, st)
    {
        rent = r;
    }

    new public void payRent(Player player){
        int[] cRoll = player.diceRoller.getRoll();
        int rollSum = cRoll[1] + cRoll[2];
        int ownsNoOfStreet = player.OwnsNoStreet(street);
        int mult = 4;
        if(ownsNoOfStreet == 2){
            mult = 10;
        } else
        player.Spends(rollSum*mult);
        owner.Earns(rollSum*mult);
    }
}
