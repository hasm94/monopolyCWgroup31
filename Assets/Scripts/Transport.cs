using UnityEngine;
using System;
using System.Collections;

public class Transport : PropertyTile {

	public String name;
	public int tValue;
	public int[] rent;

	public Tile[] NextTile;

	// Use this for initialization
	void Start (String n) {
        name = n
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
