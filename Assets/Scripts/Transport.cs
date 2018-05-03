using UnityEngine;
using System;
using System.Collections;

public class Transport : Purchasable {

    int numberOfHouses;


    new public void payRent(Player player){
        
        int ownsNoOfStreet = player.ownsNoStreet(street);
        player.spends(rent[ownsNoOfStreet-1]);
    }

}
