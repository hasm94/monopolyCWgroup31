using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

	private Monopoly theGameState;
	public DiceRoller diceRoller;

	public Tile startingTile;
	private Tile currentTile;

	private Vector3 targetPosition;
	private Vector3 velocity;
	private float smoothTime;
	private float smoothDistance;
	private float smoothHeight;

	private Tile[] moveQueue;
	private int moveQueueIndex;

	bool isAnimating = false;

	//Game logic variables, related to the abstraction of the game
	private int balance;
	private List<Purchasable> boughtProperties = new List<Purchasable>();
	private  int lapsFinished = 0;
    private bool inJail;
    private int jailFree = 0;


	// Use this for initialization
	void Start () {


		diceRoller = GameObject.FindObjectOfType<DiceRoller>();
		theGameState = GameObject.FindObjectOfType<Monopoly>();

		currentTile = startingTile;

		targetPosition = this.transform.position;
		smoothTime = 0.1f;
		smoothDistance = 0.01f;
		smoothHeight = 0.1f;

		//Gameplay initialisation
		//Change to the starting amount that the player receives
		int balance = 10000;


	}

	public void MakeMove()
	{
		if (isAnimating) {
			return;
		}


		//Debug.Log ("waiting for roll = " + theGameState.currentPhase);

		diceRoller.RollTheDice();

		//Debug.Log ("Done rolling, waiting for animation = " + theGameState.currentPhase);

		if (theGameState.isDoneRolling == false) {
			return;
		}

		//Debug.Log ("isDoneClicking should be false = " + theGameState.isDoneClicking);

		if (theGameState.isDoneClicking == true) {
			return;
		}

		int spacesToMove = diceRoller.dice[0] + diceRoller.dice[1];

		if (spacesToMove == 0) {
			return;
		}

		moveQueue = new Tile[spacesToMove];
		Tile finalTile = currentTile;

		for (int i = 0; i < spacesToMove; i++)
		{
			currentTile = (currentTile.getNextTile())[0];
			moveQueue [i] = currentTile;
		}

		//TODO: Check to see if position hosts an action.

		finalTile = currentTile;

		moveQueueIndex = 0;

		theGameState.isDoneClicking = true;
		//theGameState.currentPhase = Monopoly.TurnPhase.DONE_CLICKING;

		//Debug.Log ("is Anminating should be false = " + this.isAnimating);
		this.isAnimating = true;
		//theGameState.currentPhase = Monopoly.TurnPhase.ANIMATING;
	}

    public void MakeMoveOutOfJail()
    {
        if (isAnimating)
        {
            return;
        }

        //Debug.Log ("Done rolling, waiting for animation = " + theGameState.currentPhase);

        if (theGameState.isDoneRolling == false)
        {
            return;
        }

        //Debug.Log ("isDoneClicking should be false = " + theGameState.isDoneClicking);

        if (theGameState.isDoneClicking == true)
        {
            return;
        }

        int spacesToMove = diceRoller.dice[0] + diceRoller.dice[1];

        if (spacesToMove == 0)
        {
            return;
        }

        moveQueue = new Tile[spacesToMove];
        Tile finalTile = currentTile;

        for (int i = 0; i < spacesToMove; i++)
        {
            currentTile = (currentTile.getNextTile())[0];
            moveQueue[i] = currentTile;
        }

        //TODO: Check to see if position hosts an action.

        finalTile = currentTile;

        moveQueueIndex = 0;

        theGameState.isDoneClicking = true;
        //theGameState.currentPhase = Monopoly.TurnPhase.DONE_CLICKING;

        //Debug.Log ("is Anminating should be false = " + this.isAnimating);
        this.isAnimating = true;
        //theGameState.currentPhase = Monopoly.TurnPhase.ANIMATING;
    }
    private void AdvanceMoveQueue()
	{
		if (moveQueue != null && moveQueueIndex < moveQueue.Length) {
			Tile nextTile = moveQueue [moveQueueIndex];
			SetNewTargetPosition (nextTile.transform.position);
			moveQueueIndex++;
		}
		else {
			theGameState.isDoneAnimating = true;
			this.isAnimating = false;
			//TODO: Check that we track states properly, otherwise it wont work. Watch unity board game ep 6 from 30:54
			//theGameState.currentPhase = Monopoly.TurnPhase.DONE_ANIMATING;
		}

	}

	private void SetNewTargetPosition(Vector3 pos)
	{
		targetPosition = pos;
		velocity = Vector3.zero;
		isAnimating = true;
	}

	public void TileDescription()
	{

        Debug.Log("Landed on " + currentTile.name);

		//THIS IS TEMPORARY
//		if (theGameState.isDoneClicking && theGameState.isDoneRolling && theGameState.isDoneAnimating)
//		{
//			Debug.Log("Turn is complete!");
//			theGameState.currentPhase = Monopoly.TurnPhase.NEW_TURN;
//		}
	}

	public void DestroyToken()
	{
		Destroy (gameObject);
	}



	// Update is called once per frame
	//TODO: Animated dice display drop along when smoothdamp.y is set to 0 (Contained in second if statement
	void Update ()
	{
		if (isAnimating == false) {
			return;
		}

		if (Vector3.Distance(new Vector3(this.transform.position.x, targetPosition.y, this.transform.position.z), targetPosition) < smoothDistance) {
			//Reached target, need to check height.
			//If heighter than smoothing distance for animation, drop to zero.
			//Otherwise, move to next tile in queue.
			if (moveQueue != null && moveQueueIndex == moveQueue.Length && this.transform.position.y > smoothDistance) {
				this.transform.position = Vector3.SmoothDamp (this.transform.position, new Vector3 (this.transform.position.x, 0, this.transform.position.z), ref velocity, smoothTime);
			} else {
				AdvanceMoveQueue ();
			}
		}
		//Rise token up before traversing board.
		else if (this.transform.position.y < (smoothHeight - smoothDistance)) {
			this.transform.position = Vector3.SmoothDamp (this.transform.position, new Vector3(this.transform.position.x, smoothHeight, this.transform.position.z), ref velocity, smoothTime);
			//traverse board.
		} else {
			this.transform.position = Vector3.SmoothDamp (this.transform.position, new Vector3(targetPosition.x, smoothHeight, targetPosition.z), ref velocity, smoothTime);
		}
	}

    public Tile getCurrentTile()
    {
        return currentTile;
    }
    
    public int[] GetCurrentRoll()
    {
        return diceRoller.GetRoll();
    }


	public void Earns(int bChange){
		balance += bChange;
	}

	public void Spends(int bChange){
		balance -= bChange;
	}

    public int getBalance()
    {
        return balance;
    }

	public void BuyTile(Purchasable purchase){
		purchase.getsBoughtBy(this);
		boughtProperties.Add(purchase);
	}

	public void SellTile(Purchasable sale){
		sale.sellsProperty();
		boughtProperties.RemoveAll(z => z == sale);
	}

	public int OwnsNoStreet(Street cStreet){
		int count = 0;
		for(int i = 0; i < boughtProperties.Count; i++){
			if(boughtProperties[i].getStreet() == cStreet){
				count++;
			}
		}
		return count;
	}

    public void GoesToJail()
    {
        inJail = true;
        currentTile = Monopoly.tiles[10];
    }

    public void ReleasedFromJail()
    {
        inJail = false;
    }

    public bool IsInJail()
    {
        return inJail;
    }

    public void GetsJailFree()
    {
        jailFree++;
    }

    public void UsesJailFree()
    {
        if (jailFree > 0)
        {
            jailFree--;
            ReleasedFromJail();
        }
    }

    public int GetNumberOfHouses()
    {
        int count = 0;
        for (int i = 0; i < boughtProperties.Count; i++)
        {
            Purchasable pur = boughtProperties[i];
            if(pur.GetType() == typeof(Property))
            {
                Property prop = (Property)pur;
                int num = prop.GetNumberOfHouses();
                if (num != 5)
                {
                    count += num;
                }
            }
        }
        return count;
    }

    public int GetNumberOfHotels()
    {
        int count = 0;
        for (int i = 0; i < boughtProperties.Count; i++)
        {
            Purchasable pur = boughtProperties[i];
            if (pur.GetType() == typeof(Property))
            {
                Property prop = (Property)pur;
                int num = prop.GetNumberOfHouses();
                if (num == 5)
                {
                    count ++;
                }
            }
        }
        return count;
    }

    public void MortgageProperty(int i)
    {
        Purchasable purchase = boughtProperties[i];
        if (purchase.IsMortgaged())
        {

        }
    }

}

//if (Player.isBankrupt())
//{
//	Destroy(gameObject);
//}
