using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monopoly : MonoBehaviour {

	public enum TurnPhase {NEW_TURN,
		WAITING, DONE_CLICKING,
		WAITING_FOR_ROLL, DONE_ROLLING,
		WAITING_FOR_ANIMATION, ANIMATING, DONE_ANIMATING
	};
	public TurnPhase currentPhase;

	public bool isDoneClicking = false;
	public bool isDoneRolling = false;
	public bool isDoneAnimating = false;

	public int noPlayers;

	public Player[] players;
	public Tile[] tiles;
	public Street[] streets;
	
	public int currentPlayerId;

	public int diceTotal;

	// Use this for initialization
	void Start () {
		//TODO: Intialise players from menu
		noPlayers = PlayerPrefs.GetInt("noPlayers");
		for (int i = 5; i >= noPlayers; i--) {
			Debug.Log(i);
			players[i].destroyToken();
		}

		currentPhase = Monopoly.TurnPhase.NEW_TURN;
	}

	public void NewTurn()
	{
		if (currentPhase != TurnPhase.NEW_TURN) {
			return;
		};

		currentPhase = Monopoly.TurnPhase.WAITING;

		isDoneClicking = false;
		isDoneRolling = false;
		isDoneAnimating = false;

		//TODO: advance player via player id
		players[currentPlayerId].MakeMove();
		players[currentPlayerId].TileDescription();

		currentPlayerId = (currentPlayerId + 1) % noPlayers;

	}

	// Update is called once per frame
	void Update () {

		if (isDoneClicking && isDoneRolling && isDoneAnimating)
		{
			//Debug.Log("Turn is complete!");
			currentPhase = Monopoly.TurnPhase.NEW_TURN;
		}
	}


}
