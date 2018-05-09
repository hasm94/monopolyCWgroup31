using UnityEngine;
using System.Collections;

public class NonPurchasable : Tile {



	// Use this for initialization
	new void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public NonPurchasable(string n) : base(n)
    {
        
    }

    public void CompleteAction()
    {
        Debug.Log("Nothing has happened, there is a mistake in the code that calls nonPurchasable, rather than the subclasses");
    }

    public bool IsPurchasable()
    {
        return false;
    }
}
