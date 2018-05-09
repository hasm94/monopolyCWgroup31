using UnityEngine;
using System;
using System.Collections;

public class Transport : Purchasable {


    new void Start()
    {

    }

    void Update()
    {

    }

    public Transport(String n, int c,int[] r, Street st):base(n, c, st)
    {
        rent = r;
    }

    public void PayRent(Player player){
        
        int ownsNoOfStreet = player.OwnsNoStreet(street);
        player.Spends(rent[ownsNoOfStreet-1]);
    }

}
