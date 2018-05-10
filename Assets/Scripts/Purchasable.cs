﻿using UnityEngine;
using System;
using System.Collections;

public class Purchasable : Tile
{

    //Variables applicable to all different properties

    protected int propertyCost;
    protected Player owner;
    protected int[] rent;
    protected int mortgage;
    protected bool mortgaged;
    protected Street street;

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

    public bool HasOwner()
    {
        if (owner != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public Player GetOwner()
    {
        return owner;
    }


    public void GetsBoughtBy(Player player)
    {

        if (player.getBalance() > propertyCost && owner == null)
        {

            player.Spends(propertyCost);

            owner = player;

            player.BuyTile(this);

        }
        else
        {

            Debug.Log("Player doesn't have enough money to buy this property");

        }

    }

    public void SellsProperty()
    {

        owner = null;

        owner.Earns(propertyCost);

    }


    //Mortgages the property, adds to the players' balance

    public void MortgageProp()
    {

        owner.Earns(mortgage);

        mortgaged = true;

    }



    //Mortgage is returns

    public void PayOffMortgage()
    {

        owner.Spends(mortgage);

        mortgaged = false;

    }

    public Street GetStreet()
    {
        return street;
    }

    //Abstract method to make sure all of the subclasses have a getRent method

    public void PayRent(Player player)
    {

    }

    public new bool IsPurchasable()
    {
        return true;
    }

    public bool IsMortgaged()
    {
        return mortgaged;
    }



}
