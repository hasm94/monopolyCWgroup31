using UnityEngine;
using System;
using System.Collections;

public class Property : Purchasable {

    int numberOfHouses;


    // Use this for initialization
    new void Start ()
    {
	}

	// Update is called once per frame
	void Update () {

	}

    public Property(String n, int c, int[] r, Street st):base(n, c, st)
    {
        name = n;
        rent = r;
        numberOfHouses = 0;

    }

    new public void payRent(Player player){
        player.Spends(base.rent[numberOfHouses]);
    }

    public void buildHouse(){
        numberOfHouses++;
        owner.Spends(street.getHouseCost());
    }

    public void sellHouse(){
        numberOfHouses--;
        owner.Earns(street.getHouseCost());
    }

}
