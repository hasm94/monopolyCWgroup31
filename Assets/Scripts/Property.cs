using UnityEngine;
using System;
using System.Collections;

public class Property : PropertyTile {

	public enum Colour {MAROON, NAVY_BLUE, PINK, ORANGE, RED, YELLOW, GREEN, BLUE};

    
    //Variety of variables that define the base information of the property, 
	public static String name;
	public static int cost;
	public static int houseValue;
	public static int mortageValue;
    public static int[] rent;
    public int noOfHouses;
    public Player owner;
	public Colour colour;

    
	public Tile[] NextTile;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    
}
