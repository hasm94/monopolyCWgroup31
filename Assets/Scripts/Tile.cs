using UnityEngine;
using System;
using System.Collections;

public class Tile : MonoBehaviour {

    
    private String tileName;
	private Tile[] nextTile;

	// Use this for initialization
	public void Start (String n, Tile[] nt) {
        name = n;
        nextTile = nt;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public String getName(){
        return tileName;
    }
    
    public Tile[] getNextTile(){
        return nextTile;
    }

    public bool isPurchasable()
    {
        return false;
    }
}
