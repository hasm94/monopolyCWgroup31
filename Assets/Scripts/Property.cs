using UnityEngine;
using System;
using System.Collections;

public class Property : Tile {

	public enum Colour {MAROON, NAVY_BLUE, PINK, ORANGE, RED, YELLOW, GREEN, BLUE};
	public Colour colour;

	//public String name;
	public int initialValue;
	public int hotelValue;
	public int mortageValue;

	public Tile[] NextTile;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
