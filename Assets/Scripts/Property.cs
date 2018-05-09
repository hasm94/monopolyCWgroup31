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

    public void PayRent(Player player){
        player.Spends(base.rent[numberOfHouses]);
    }

    public void BuildHouse(){
        numberOfHouses++;
        owner.Spends(street.getHouseCost());
    }

    public void SellHouse(){
        numberOfHouses--;
        owner.Earns(street.getHouseCost());
    }

    public int GetNumberOfHouses()
    {
        return numberOfHouses;
    }
}
