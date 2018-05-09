using UnityEngine;
using System;
using System.Collections;

public class Street {

    //Class to represent the abstract street of properties. Baisc functionality, and ease of use to minimize searching in the game

    //Basic variables, that are needed to calculate different things
    public Colour streetColour;
	private int noOfProperties;
    private Purchasable[] properties = new Purchasable[4];
    private int houseCost;

    //Constructor method
    public Street(Colour col, int cHouse){
        streetColour = col;
        houseCost = cHouse;
    }

    public Street(Colour col)
    {
        streetColour = col;
    }

    public void addProperty(Purchasable pur)
    {
        if (noOfProperties == 5)
        {
            Debug.Log("There are too many properties in this street, check your code");
        } else
        {
            properties[noOfProperties] = pur;
            noOfProperties++;
        }

    }

    //returns the cost of houses that can be built on the street
    public int getHouseCost(){
        return houseCost;
    }

    //Checks if the player owns all of the properties in this street
    public bool checkIfOwned(Player player){
        for(int i = 0; i < noOfProperties; i++){
            if(player != properties[i].GetOwner()){
                return false;
            }
        }
        return true;
    }

    public Colour getColour(){
		return streetColour;
	}



}
