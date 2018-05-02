using UnityEngine;
using System;
using System.Collections;

public class Transport : Purchasable {

    int numberOfHouses;


    public void payRent(Player player){
        utilStreet = Monopoly.getStreet(UTILITY);
        int ownsNoOfStreet = player.ownsNoStreet(utilStreet);
        player.spends(rent[ownsNoOfStreet-1]);
    }

}
