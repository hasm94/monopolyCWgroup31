using UnityEngine;
using System;
using System.Collections;

public class Utility : Purchasable {

    int numberOfHouses;

	// Use this for initialization
	void Start (String n, Tile[] nt, int c, Colour col)
    : base(n, nt, c, col) {
        numberOfHouses = 0;
	}

	// Update is called once per frame
	void Update () {

	}

    public void payRent(Player player){
        int[] cRoll = DiceRoller.dice;
        int rollSum = cRoll[1] + cRoll[2];
        utilStreet = Monopoly.getStreet(UTILITY);
        int ownsNoOfStreet = player.ownsNoStreet(utilStreet);
        int mult = 4;
        if(ownsNoOfStreet = 2){
            mult = 10;
        } else
        player.spends(rollSum*mult);
        owner.earns(rollSum*mult);
    }
}
