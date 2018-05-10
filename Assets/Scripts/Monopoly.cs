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

        #region Board Declaration: This is the code section where the board is set up
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
        #endregion

        #region Card Declaration: Where both of the card piles are made

        Card[] tempPLCardPile = new Card[16];
        Card[] tempOKCardPile = new Card[16];


        Action act = new Action(1, 100);
        tempPLCardPile[0] = new Card("You inherit £100", act);
        act = new Action(1, 20);
        tempPLCardPile[1] = new Card("You have won 2nd prize in a beauty contest, collect £20", act);
        act = new Action(5, 1);
        tempPLCardPile[2] = new Card("Go back to Crapper Street", act);
        act = new Action(1, 20);
        tempPLCardPile[3] = new Card("Student loan refund. Collect £20", act);
        act = new Action(1, 200);
        tempPLCardPile[4] = new Card("Bank error in your favour.Collect £200", act);
        act = new Action(2, 100);
        tempPLCardPile[5] = new Card("Pay bill for text books of £100", act);
        act = new Action(1, 50);
        tempPLCardPile[6] = new Card("Mega late night taxi bill pay £50", act);
        act = new Action(4, 0);
        tempPLCardPile[7] = new Card("Advance to go", act);
        act = new Action(1, 50);
        tempPLCardPile[8] = new Card("From sale of Bitcoin you get £50", act);
        act = new Action(7, 100);
        tempPLCardPile[9] = new Card("Pay a £10 fine or take opportunity knocks", act);
        act = new Action(3, 50);
        tempPLCardPile[10] = new Card("Pay insurance fee of £50", act);
        act = new Action(1, 100);
        tempPLCardPile[11] = new Card("Savings bond matures, collect £100", act);
        act = new Action(8, 0);
        tempPLCardPile[12] = new Card("Go to jail. Do not pass GO, do not collect £200", act);
        act = new Action(1, 25);
        tempPLCardPile[13] = new Card("Received interest on shares of £25", act);
        act = new Action(7, 10);
        tempPLCardPile[14] = new Card("It's your birthday. Collect £10 from each player", act);
        act = new Action(9, 100);
        tempPLCardPile[15] = new Card("Get out of Jail free", act);

        act = new Action(1, 50);
        tempOKCardPile[0] = new Card("Bank pays you a dividend ofd £50", act);
        act = new Action(1, 100);
        tempOKCardPile[1] = new Card("You won a lip sync battle. Collect £100", act);
        act = new Action(4, 39);
        tempOKCardPile[2] = new Card("Advance to Turing Heights", act);
        act = new Action(4, 24);
        tempOKCardPile[3] = new Card("Advance to Han Xin Gardens", act);
        act = new Action(2, 15);
        tempOKCardPile[4] = new Card("Fined £15 for speeding", act);
        act = new Action(2, 150);
        tempOKCardPile[5] = new Card("Pay university fees of £150", act);
        act = new Action(10, 40, 115);
        tempOKCardPile[6] = new Card("You are assessed for repairs, £40/house, £115/hotel", act);
        act = new Action(4, 0);
        tempOKCardPile[7] = new Card("Advance to Go", act);
        act = new Action(10, 15, 100);
        tempOKCardPile[8] = new Card("You are assessed for repairs £25/house, £100/hotel", act);
        act = new Action(5, 3);
        tempOKCardPile[9] = new Card("Go back 3 spaces", act);
        act = new Action(4, 11);
        tempOKCardPile[10] = new Card("Advance to Skywalker Drive. If you pass Go collect £200", act);
        act = new Action(8, 0);
        tempOKCardPile[11] = new Card("Go to Jail. Do not pass Go, do not collect £200", act);
        act = new Action(2, 20);
        tempOKCardPile[12] = new Card("Drunk in charge of a skateboard. Fine £20", act);
        act = new Action(9, 0);
        tempOKCardPile[13] = new Card("Get out of jail free", act);
        act = new Action(4, 15);
        tempOKCardPile[14] = new Card("Take a trip to Hove station. If you pass GO collect £200", act);
        act = new Action(1, 150);
        tempOKCardPile[15] = new Card("Loan matures, collect £150", act);

        CardPiles.SetOKCards(tempOKCardPile);
        CardPiles.SetPLCards(tempPLCardPile);

        #endregion


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
                Debug.Log("Player can purchase the property");
                //TODO: Popup for actions: buy property = true, or send to auction  = false.

                if (buy)
                {
                    cPlayer.BuyTile(pTile);
                    Debug.Log("Property is sold");
                } else
                {
                    Debug.Log("Property is up for auction");
                    int length = players.Length;
                    int[] offers = new int[length];

                    //TODO add menu for auction, everyone can choose a value, then highest is selected, that player buys the house

                    int idHighestBid = -1;
                    int highestBid = 0;
                    for (int i = 0; i < length; i++)
                    {
                        if (offers[i] > highestBid)
                        {
                            idHighestBid = i;
                        }
                    }
                    if (idHighestBid != -1)
                    {
                        players[idHighestBid].BuyTile(pTile);
                        Debug.Log("Property sold, at: £" + highestBid);
                    } else
                    {
                        Debug.Log("Property not sold, and is till on the market");
                    }

                }


            }
		} else {

			NonPurchasable upTile = (NonPurchasable) cTile;
			Debug.Log ("You have landed on " + cTile.name + ". Complete given action");

            //TODO show the player what tile they landed on, and the effect

			upTile.CompleteAction();


		}

	}

    public void OpenActions()
    {

        Debug.Log("Player can complete his business transactions");
        bool cont = false ;

        Player cPlayer = players[currentPlayerId];
        while (cont)
        {
            int option = 0;

            //Add a menu to select different actions

            switch (option)
            {
                case 0:
                    Debug.Log("Player ended their turn");
                    break;
                case 1:
                    Debug.Log("Player sold property");
                    //TODO add menu to sell properties
                    break;
                case 2:
                    Debug.Log("Player Mortgaged property");
                    //TODO
                    break;
                case 3:
                    Debug.Log("Player Built houses");
                    //TODO
                    break;
                case 4:
                    Debug.Log("Player sold houses");
                    //TODO
                    break;
                case 5:
                    Debug.Log("Viewed Property of other players");
                    //TODO
                    break;
                case 6:
                    Debug.Log("Player conceded");
                    //TODO
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
