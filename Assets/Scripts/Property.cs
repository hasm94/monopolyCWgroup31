using UnityEngine;
using System;
using System.Collections;

public class Property : Purchasable {

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
        player.spends(base.rent[numberOfHouses]);
    }

    public void buildHouse(){
        numberOfHouses++;
        owner.spends(street.getHouseCost());
    }

    public void sellHouse(){
        numberOfHouses--;
        owner.earns(street.getHouseCost());
    }
}
