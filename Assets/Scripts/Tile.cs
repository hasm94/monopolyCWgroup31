using UnityEngine;
using System;
using System.Collections;

public class Tile : MonoBehaviour {

    
    private String name;
	private Tile[] NextTile;

	// Use this for initialization
	void Start (String n, Tile[] nt) {
        name = n;
        NextTile = nt;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public String getName(){
        return name;
    }
    
    public Tile[] getNextTile(){
        return NextTile;
    }
}
