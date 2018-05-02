using UnityEngine;
using System;
using System.Collections;

public class Street {

    //Class to represent the abstract street of properties. Baisc functionality, and ease of use to minimize searching in the game

    //Basic variables, that are needed to calculate different things
    public Colour streetColour;
	private int noOfProperties;
    private Property[] properties;
    private int houseCost;

    //Constructor method
    public Street(Colour col, Property[] props, int costOfHouse){
        streetColour = col;
        properties = props;
        noOfProperties = props.Length;
        costOfHouse = houseCost;
    }

    //returns the cost of houses that can be built on the street
    public int getHouseCost(){
        return houseCost;
    }

    //Checks if the player owns all of the properties in this street
    public boolean checkIfOwned(Player player){
        for(int i = 0; i < noOfProperties; i++){
            if(player != properties[i].getOwner()){
                return false;
            }
        }
        return true;
    }


}
