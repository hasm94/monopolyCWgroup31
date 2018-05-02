using UnityEngine;
using System;
using System.Collections;

public class Purchasable : Tile {


    //Variables applicable to all different properties
    private String name;
	private Tile[] NextTile;
    private int propertyCost;
    private Player owner;
    private int mortgage;
    private boolean isMortgaged;

	// Use this for initialization
	void Start (String n, Tile[] nt int c)
    : base(n, nt) {
        name = n;
        NextTile = nt;
        cost = c;
        owner = null;
	}

	// Update is called once per frame
	void Update () {

	}

    //Returns the name of the property
    public String getName(){
        return name;
    }

    public Tile[] getNextTile(){
        return NextTile;
    }

    //Is run when a player wants to own a property, checks that the playre has enough on their balance
    public void getsBoughtBy(Player player){
        if(player.getBalance() > propertyCost && owner == null){
            player.spends(cost);
            owner = player;
            player.addProperty(this);
        } else {
            System.Write("Player doesn't have enough money to buy this property");
        }
    }

    //Mortgages the property, adds to the players' balance
    public void mortgageProp(){
        owner.earns(mortgage);
        isMortgaged = True;
    }

    //Mortgage is returns
    public void payOffMortgage(){
        owner.spends(mortgage);
        isMortgaged = false;
    }

    public abstract
}
