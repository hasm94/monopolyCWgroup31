using UnityEngine;
using System;
using System.Collections;

public class Purchasable : Tile {

    //Variables applicable to all different properties

    protected int propertyCost;
	protected Player owner;
	protected int[] rent;
	protected int mortgage;
    protected bool mortgaged;
    protected Street street;

	// Use this for initialization

	public void Start (String n, Tile[] nt, int c, Street st) {

        base.Start(n, nt);
		propertyCost = c;
		owner = null;
		street = st;

	}



	// Update is called once per frame

	void Update () {



	}

	public bool hasOwner() {
		if (owner != null) {
			return true;
		} else {
			return false;
		}

	}

    public Player getOwner()
    {
        return owner;
    }

	//Is run when a player wants to own a property, checks that the playre has enough on their balance

	public void getsBoughtBy(Player player){

		if(player.getBalance() > propertyCost && owner == null){

			player.spends(propertyCost);

			owner = player;

			player.buyTile(this);

		} else {

			Debug.Log("Player doesn't have enough money to buy this property");

		}

	}

	public void sellsProperty(){

		owner = null;

		owner.earns(propertyCost);

	}


	//Mortgages the property, adds to the players' balance

	public void mortgageProp(){

		owner.earns(mortgage);

		mortgaged = true;

	}



	//Mortgage is returns

	public void payOffMortgage(){

		owner.spends(mortgage);

		mortgaged = false;

	}

	public Street getStreet(){
		return street;
	}

	//Abstract method to make sure all of the subclasses have a getRent method

	public void payRent(Player player)
    {

    }

    public new bool isPurchasable()
    {
        return true;
    }

    public bool isMortgaged()
    {
        return mortgaged;
    }



}
