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

	new public void Start () {

	}



	// Update is called once per frame

	void Update () {



	}

    public Purchasable(String n, Tile[] nt, int c, Street st) : base(n, nt)
    {
        propertyCost = c;
        owner = null;
        street = st;
    }

    public Purchasable(String n, int c, Street st) : base(n)
    {
        propertyCost = c;
        owner = null;
        street = st;
    }



	public bool hasOwner() {
		if (owner != null) {
			return true;
		} else {
			return false;
		}

	}

    public Player GetOwner()
    {
        return owner;
    }

	//Is run when a player wants to own a property, checks that the playre has enough on their balance

	public void getsBoughtBy(Player player){

		if(player.getBalance() > propertyCost && owner == null){

			player.Spends(propertyCost);

			owner = player;

			player.BuyTile(this);

		} else {

			Debug.Log("Player doesn't have enough money to buy this property");

		}

	}

	public void sellsProperty(){

		owner = null;

		owner.Earns(propertyCost);

	}


	//Mortgages the property, adds to the players' balance

	public void mortgageProp(){

		owner.Earns(mortgage);

		mortgaged = true;

	}



	//Mortgage is returns

	public void payOffMortgage(){

		owner.Spends(mortgage);

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
