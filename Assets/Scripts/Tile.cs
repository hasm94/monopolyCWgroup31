using UnityEngine;
using System;
using System.Collections;

public class Tile : MonoBehaviour {

    
    private String tileName;
	private Tile[] nextTile;

	// Use this for initialization
	public void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Tile(String n, Tile[] nt)
    {
        name = n;
        nextTile = nt;
    }

    public Tile(String n)
    {
        name = n;
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
