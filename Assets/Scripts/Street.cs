using UnityEngine;
using System;
using System.Collections;

public class Street {


    public Colour streetColour;
	private int noOfProperties;
    private Property[] properties;
    private int houseCost;

    public Street(Colour col, Property[] props, int costOfHouse){
        streetColour = col;
        properties = props;
        noOfProperties = props.Length;
        costOfHouse = houseCost;
    }

    public int getHouseCost(){
        return houseCost;
    }

    public boolean checkIfOwned(Player player){
        for(int i = 0; i < noOfProperties; i++){
            if(player != properties[i].getOwner()){
                return false;
            }
        }
        return true;
    }


}
