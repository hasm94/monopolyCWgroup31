using UnityEngine;
using System;
using System.Collections;

public class Property : Purchasable {

    int numberOfHouses;

	// Use this for initialization
	void Start (String n, Tile[] nt, int c, Colour col)
    : base(n, nt, c, col) {
        numberOfHouses = 0;
	}

	// Update is called once per frame
	void Update () {

	}

    public String getName(){
        return name;
    }

    public Tile[] getNextTile(){
        return NextTile;
    }

    public void payRent(Player player){
        player.spend(rent[numberOfHouses]);
    }

    public void buildHouse(){
        numberOfHouses++;
        owner.spends(houseCost);
    }

    public void sellHouse(){
        numberOfHouses--;
        owner.earns(houseCost);
    }
}
