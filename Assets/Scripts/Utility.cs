using UnityEngine;
using System;
using System.Collections;

public class Utility : Purchasable {

    int numberOfHouses;

	// Use this for initialization
	new void Start (String n, Tile[] nt, int c, Street st)
    {
        base.Start(n, nt, c, st);
        numberOfHouses = 0;
	}

	// Update is called once per frame
	void Update () {

	}

    new public void payRent(Player player){
        int[] cRoll = player.diceRoller.getRoll();
        int rollSum = cRoll[1] + cRoll[2];
        int ownsNoOfStreet = player.ownsNoStreet(street);
        int mult = 4;
        if(ownsNoOfStreet == 2){
            mult = 10;
        } else
        player.spends(rollSum*mult);
        owner.earns(rollSum*mult);
    }
}
