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

	public bool newTurnPossible = true;

	public int noPlayers;

	public static Player[] players;
	public static Tile[] tiles;
    public Street[] streets;
    public static int freeParkingVal;
	public int currentPlayerId;
    

	public int diceTotal;

	// Use this for initialization
	void Start () {
        //Initialise the tiles
        tiles = new Tile[40];
        streets = new Street[10];

        Street brown = new Street(Colour.BROWN, 50);
        Street blue = new Street(Colour.BLUE, 50);
        Street green = new Street(Colour.GREEN, 200);
        Street purple = new Street(Colour.PURPLE, 100);
        Street red = new Street(Colour.RED, 150);
        Street yellow = new Street(Colour.YELLOW, 150);
        Street orange = new Street(Colour.ORANGE, 100);
        Street d_blue = new Street(Colour.DEEP_BLUE, 200);

        Street utility = new Street(Colour.UTILITY);
        Street station = new Street(Colour.TRANSPORT);

        streets[0] = brown;
        streets[1] = blue;
        streets[2] = purple;
        streets[3] = orange;
        streets[4] = red;
        streets[5] = yellow;
        streets[6] = green;
        streets[7] = d_blue;
        streets[8] = station;
        streets[9] = utility;


        int[] r1 = { 2, 10, 30, 90, 160, 250 };
        int[] r2 = { 4, 20, 60, 180, 320, 450 };
        int[] r3 = { 6, 30, 90, 270, 400, 550 };
        int[] r4 = { 6, 30, 90, 270, 400, 550 };
        int[] r5 = { 8, 40, 100, 300, 450, 600 };
        int[] r6 = { 10, 50, 150, 450, 625, 750 };
        int[] r7 = { 10, 50, 150, 450, 625, 750 };
        int[] r8 = { 12, 60, 180, 500, 700, 900 };
        int[] r9 = { 14, 70, 200, 550, 750, 950 };
        int[] r10 = { 14, 70, 200, 550, 750, 950 };
        int[] r11 = { 16, 80, 220, 600, 800, 1000 };
        int[] r12 = { 18, 90, 250, 700, 875, 1050 };
        int[] r13 = { 18, 90, 250, 700, 875, 1050 };
        int[] r14 = { 20, 100, 300, 750, 925, 1100 };
        int[] r15 = { 22, 110, 330, 800, 975, 1150 };
        int[] r16 = { 22, 110, 330, 800, 975, 1150 };
        int[] r17 = { 22, 120, 360, 850, 1025, 1200 };
        int[] r18 = { 26, 130, 390, 900, 1100, 1275 };
        int[] r19 = { 26, 130, 390, 900, 1100, 1275 };
        int[] r20 = { 28, 150, 450, 1000, 1200, 1400 };
        int[] r21 = { 35, 175, 500, 1100, 1300, 1500 };
        int[] r22 = { 50, 200, 600, 1400, 1700, 2000 };

        int[] rOther = { 0, 25, 50, 100 };

        tiles[0] = new Go("Go");
        tiles[1] = new Property("Crapper Street", 60, r1, brown);
        tiles[2] = new PotLuck("Potluck");
        tiles[3] = new Property("Gangster Paradise", 60, r2, brown);
        tiles[4] = new TaxTile("Income Tax", 200);
        tiles[5] = new Transport("Brighton Station", 200, rOther, station);
        tiles[6] = new Property("Weeping Angel", 100, r3, blue);
        tiles[7] = new OpportunityKnocks("Opportunity Knocks");
        tiles[8] = new Property("Potts Avenue", 100, r4, blue);
        tiles[9] = new Property("Nardole Drive", 120, r5, blue);
        tiles[10] = new Jail("Jail");
        tiles[11] = new Property("Skywalker Drive", 140, r6, purple);
        tiles[12] = new Utility("Tesla Power Co", 150, rOther, utility);
        tiles[13] = new Property("Wookie Hole", 140, r7, purple);
        tiles[14] = new Property("Rey Lane", 160, r8, purple);
        tiles[15] = new Transport("Hove Station", 200, rOther, station);
        tiles[16] = new Property("Cooper Drive", 180, r9, orange);
        tiles[17] = new PotLuck("Potluck");
        tiles[18] = new Property("Wolowitz Street", 180, r10, orange);
        tiles[19] = new Property("Penny Lane", 200, r11, orange);
        tiles[20] = new FreeParking("Free Parking");
        tiles[21] = new Property("Yue Fei Square", 220, r12, red);
        tiles[22] = new OpportunityKnocks("Opportunity Knocks");
        tiles[23] = new Property("Mulan Rouge", 220, r13, red);
        tiles[24] = new Property("Han Xin Gardens", 240, r14, red);
        tiles[25] = new Transport("Falmer Station", 200, rOther, station);
        tiles[26] = new Property("Kirk Close", 260, r15, yellow);
        tiles[27] = new Property("Picard Avenue", 260, r16, yellow);
        tiles[28] = new Utility("Edison Water", 150, rOther, utility);
        tiles[29] = new Property("Crusher Creek", 280, r17, yellow);
        tiles[30] = new GoToJail("Go to Jail");
        tiles[31] = new Property("Sirat Mews", 300, r18, green);
        tiles[32] = new Property("Ghengis Crescent", 300, r19, green);
        tiles[33] = new PotLuck("Potluck");
        tiles[34] = new Property("Ibis Close", 320, r20, green);
        tiles[35] = new Transport("Lewes Station", 200, rOther, station);
        tiles[36] = new OpportunityKnocks("Opportunity Knocks");
        tiles[37] = new Property("Hawking Way", 350, r21, d_blue);
        tiles[38] = new TaxTile("Super Tax", 100);
        tiles[39] = new Property("Turing Heights", 400, r22, d_blue);


        


        //TODO: Intialise players from menu
        noPlayers = PlayerPrefs.GetInt("noPlayers");
		for (int i = 5; i >= noPlayers; i--) {
			Debug.Log(i);
			players[i].DestroyToken();
		}

		currentPhase = Monopoly.TurnPhase.NEW_TURN;
	}

	public void NewTurn()
	{

//		
		if (newTurnPossible) {
			newTurnPossible = false;
		} else {
			Debug.Log ("Wait till turn is over");
			return;
		}
//			currentPhase = Monopoly.TurnPhase.WAITING;

			isDoneClicking = false;
			isDoneRolling = false;
			isDoneAnimating = false;

        //TODO: advance player via player id

        Player cPlayer = players[currentPlayerId];


        //This is a really ugly if statement and should be improved.
        if (cPlayer.IsInJail())
        {
            cPlayer.diceRoller.RollTheDice();
            int[] first = cPlayer.GetCurrentRoll();
            if (first[0] == first[1])
            {
                Debug.Log("Player got out of Jail");
                cPlayer.MakeMoveOutOfJail();
            } else
            {
                int[] second = cPlayer.GetCurrentRoll();
                if (second[0] == second[1])
                {
                    Debug.Log("Player got out of Jail");
                    cPlayer.MakeMoveOutOfJail();
                }
                else
                {
                    int[] third = cPlayer.GetCurrentRoll();
                    if (third[0] == third[1])
                    {
                        Debug.Log("Player got out of Jail");
                        cPlayer.MakeMoveOutOfJail();
                    } else
                    {
                        Debug.Log("Player didn't get out of Jail");
                    }
                }
            }
        } else {
           cPlayer.MakeMove();
        }

        PossibleActions();
        OpenActions();




        /*if (players[currentPlayerId].diceRoller.isRolledOver) {
            Debug.Log ("isDoneClicking should be false = " + isDoneClicking);
            Debug.Log ("isDoneRolling should be false = " + isDoneRolling);
            Debug.Log ("isDoneAnimating should be false = " + isDoneAnimating);
            return;
        }
        */

        players[currentPlayerId].TileDescription ();

			currentPlayerId = (currentPlayerId + 1) % noPlayers;
//		}

	}


    public void PossibleActions()
    {

        Player cPlayer = players[currentPlayerId];

        Tile cTile = players[currentPlayerId].getCurrentTile();

		if (cTile.isPurchasable()) {
            Purchasable pTile = (Purchasable)cTile;
			Debug.Log ("You have landed on a purchasable tile.");
			if (pTile.HasOwner ()) {
				if (pTile.GetOwner () == players [currentPlayerId]) {
					Debug.Log ("You landed on your own tile. Do nothing.");
					return;
				} else {
					Debug.Log ("You have landed on a tile that is owned by another player.");

                    if (pTile.IsMortgaged()) {
                        //nothing happens
                        Debug.Log("This tile is mortgaged. Do nothing.");
                        return;
                    } else if(pTile.GetOwner().IsInJail())
                    {
                        //nothing happens
                        Debug.Log("The owne is in prison. Do nothing.");
                        return;
                    } else {
						Debug.Log ("pay player" + pTile.GetOwner() + " a rent of " + pTile);
						pTile.payRent (players [currentPlayerId]);
					}
				}
			
			} else {

                bool buy = true;
                //TODO: Popup for actions: buy property = true, or send to auction  = false.

                if (buy)
                {
                    cPlayer.BuyTile(pTile);
                } else
                {

                }


			}
		} else {

			NonPurchasable upTile = (NonPurchasable) cTile;
			Debug.Log ("You have landed on " + cTile.name + ". Complete given action");
			upTile.CompleteAction();


		}

	}

    public void OpenActions()
    {
        bool cont = false ;
        Player cPlayer = players[currentPlayerId];
        while (cont)
        {
            int option = 0;

            switch (option)
            {
                case 1:
                    //Mortgage Option
                    int indexOfMortgage = 0;

                    //Add property selection screen

                    

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    cont = false;
                    break;
            }
        }
    }




	// Update is called once per frame
	void Update () {

		if (isDoneClicking && isDoneRolling && isDoneAnimating)
		{
			//Debug.Log("Turn is complete!");
			newTurnPossible = true;
			currentPhase = Monopoly.TurnPhase.NEW_TURN;
		}
	}
	
	public int getStreetId(Colour colour){
		for(int i = 0; i < streets.Length; i++){
			if(streets[i].streetColour == colour){
				return i;
			}
		}
		return -1;
	}
}
