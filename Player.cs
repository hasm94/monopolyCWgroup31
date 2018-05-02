using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

	private Monopoly theGameState;
	private DiceRoller diceRoller;

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


	// Use this for initialization
	void Start () {

			
		diceRoller = GameObject.FindObjectOfType<DiceRoller>();
		theGameState = GameObject.FindObjectOfType<Monopoly>();

		currentTile = startingTile;

		targetPosition = this.transform.position;
		smoothTime = 0.1f;
		smoothDistance = 0.01f;
		smoothHeight = 0.1f;
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
			currentTile = currentTile.NextTile[0];
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

		if (currentTile == theGameState.tiles [1]) {
			Debug.Log ("You landed on Meditarranean Avenue");
		} else if (currentTile == theGameState.tiles [2]) {
			Debug.Log ("You landed on Opportunity Knocks");
		} else if (currentTile == theGameState.tiles [3]) {
			Debug.Log ("You landed on Baltic Avenue");
		} else if (currentTile == theGameState.tiles [4]) {
			Debug.Log ("You landed on Income tax. Pay 10% or $200");
		} else if (currentTile == theGameState.tiles [5]) {
			Debug.Log ("You landed on Reading Railroad");
		} else if (currentTile == theGameState.tiles [6]) {
			Debug.Log ("You landed on Oriental Avenue");
		} else if (currentTile == theGameState.tiles [7]) {
			Debug.Log ("You landed on Put Luck");
		} else if (currentTile == theGameState.tiles [8]) {
			Debug.Log ("You landed on Vermont Avenue");
		} else if (currentTile == theGameState.tiles [9]) {
			Debug.Log ("You landed on Connecticut Avenue");
		} else if (currentTile == theGameState.tiles [10]) {
			Debug.Log ("You landed on Baltic Avenue");
		} else if (currentTile == theGameState.tiles [11]) {
			Debug.Log ("You landed on Just Visiting");
		} else if (currentTile == theGameState.tiles [12]) {
			Debug.Log ("You landed on St.Charles Place");
		} else if (currentTile == theGameState.tiles [13]) {
			Debug.Log ("You landed on Electric Company");
		} else if (currentTile == theGameState.tiles [14]) {
			Debug.Log ("You landed on States Avenue");
		} else if (currentTile == theGameState.tiles [15]) {
			Debug.Log ("You landed on Virginia Avenue");
		} else if (currentTile == theGameState.tiles [16]) {
			Debug.Log ("You landed on Pennsylvania Railroad");
		} else if (currentTile == theGameState.tiles [17]) {
			Debug.Log ("You landed on St.James Place");
		} else if (currentTile == theGameState.tiles [18]) {
			Debug.Log ("You landed on Tennessee Avenue");
		} else if (currentTile == theGameState.tiles [19]) {
			Debug.Log ("You landed on New York Avenue");
		} else if (currentTile == theGameState.tiles [20]) {
			Debug.Log ("You landed on Free Parking");
		} else if (currentTile == theGameState.tiles [21]) {
			Debug.Log ("You landed on Kentucky Avenue");
		} else if (currentTile == theGameState.tiles [22]) {
			Debug.Log ("You landed on Put Luck");
		} else if (currentTile == theGameState.tiles [23]) {
			Debug.Log ("You landed on Indiana Avenue");
		} else if (currentTile == theGameState.tiles [24]) {
			Debug.Log ("You landed on Illinois Avenue");
		} else if (currentTile == theGameState.tiles [25]) {
			Debug.Log ("You landed on B & O Railroad");
		} else if (currentTile == theGameState.tiles [26]) {
			Debug.Log ("You landed on Atlantic Avenue");
		} else if (currentTile == theGameState.tiles [27]) {
			Debug.Log ("You landed on Ventor Avenue");
		} else if (currentTile == theGameState.tiles [28]) {
			Debug.Log ("You landed on Water Works");
		} else if (currentTile == theGameState.tiles [29]) {
			Debug.Log ("You landed on Marvin Gardens");
		} else if (currentTile == theGameState.tiles [30]) {
			Debug.Log ("GO TO JAIL!");
			currentTile = theGameState.tiles [10];
		} else if (currentTile == theGameState.tiles [31]) {
			Debug.Log ("You landed on Pacific Avenue");
		} else if (currentTile == theGameState.tiles [32]) {
			Debug.Log ("You landed on North Carolina Avenue");
		} else if (currentTile == theGameState.tiles [33]) {
			Debug.Log ("You landed on Opportunity Knocks");
		} else if (currentTile == theGameState.tiles [34]) {
			Debug.Log ("You landed on Pennsylvania Avenue");
		} else if (currentTile == theGameState.tiles [35]) {
			Debug.Log ("You landed on Short Line");
		} else if (currentTile == theGameState.tiles [36]) {
			Debug.Log ("You landed on Put Luck");
		} else if (currentTile == theGameState.tiles [37]) {
			Debug.Log ("You landed on Park Place");
		} else if (currentTile == theGameState.tiles [38]) {
			Debug.Log ("You landed on Luxury Tax");
		} else if (currentTile == theGameState.tiles [39]) {
			Debug.Log ("You landed on Broadwalk");
		} else {
			Debug.Log ("Tile: GO!");
		}

		//THIS IS TEMPORARY
//		if (theGameState.isDoneClicking && theGameState.isDoneRolling && theGameState.isDoneAnimating)
//		{
//			Debug.Log("Turn is complete!");
//			theGameState.currentPhase = Monopoly.TurnPhase.NEW_TURN;
//		}
	}

	public void destroyToken()
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

}

//if (Player.isBankrupt())
//{
//	Destroy(gameObject);
//}
