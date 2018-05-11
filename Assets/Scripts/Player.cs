// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>The player class.</summary>
// ***********************************************************************
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class Player.
/// </summary>
public class Player : MonoBehaviour
{

    /// <summary>
    /// The game state
    /// </summary>
    private Monopoly theGameState;
    /// <summary>
    /// The dice roller
    /// </summary>
    public DiceRoller diceRoller;

    /// <summary>
    /// The starting tile
    /// </summary>
    public Tile startingTile;
    /// <summary>
    /// The current tile
    /// </summary>
    private Tile currentTile;

    /// <summary>
    /// The target position
    /// </summary>
    private Vector3 targetPosition;
    /// <summary>
    /// The velocity
    /// </summary>
    private Vector3 velocity;
    /// <summary>
    /// The smooth time
    /// </summary>
    private float smoothTime;
    /// <summary>
    /// The smooth distance
    /// </summary>
    private float smoothDistance;
    /// <summary>
    /// The smooth height
    /// </summary>
    private float smoothHeight;

    /// <summary>
    /// The move queue
    /// </summary>
    private Tile[] moveQueue;
    /// <summary>
    /// The move queue index
    /// </summary>
    private int moveQueueIndex;

    /// <summary>
    /// The is animating
    /// </summary>
    bool isAnimating = false;

    //Game logic variables, related to the abstraction of the game
    /// <summary>
    /// The balance
    /// </summary>
    private int balance;
    /// <summary>
    /// The bought properties
    /// </summary>
    private List<Purchasable> boughtProperties = new List<Purchasable>();
    /// <summary>
    /// The laps finished
    /// </summary>
    private int lapsFinished = 0;
    /// <summary>
    /// The in jail
    /// </summary>
    private bool inJail;
    /// <summary>
    /// The number of times the player can get out of jail for free
    /// </summary>
    private int jailFree = 0;


    // Use this for initialization
    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
    {


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

    /// <summary>
    /// Makes the move for the player.
    /// </summary>
    public void MakeMove()
    {
        if (isAnimating)
        {
            return;
        }


        //Debug.Log ("waiting for roll = " + theGameState.currentPhase);

        diceRoller.RollTheDice();

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
            currentTile = (currentTile.GetNextTile())[0];
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

    /// <summary>
    /// Makes the move out of jail, if they had to roll to get out.
    /// </summary>
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
            currentTile = (currentTile.GetNextTile())[0];
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
    /// <summary>
    /// Advances the move queue.
    /// </summary>
    private void AdvanceMoveQueue()
    {
        if (moveQueue != null && moveQueueIndex < moveQueue.Length)
        {
            Tile nextTile = moveQueue[moveQueueIndex];
            SetNewTargetPosition(nextTile.transform.position);
            moveQueueIndex++;
        }
        else
        {
            theGameState.isDoneAnimating = true;
            this.isAnimating = false;
            //TODO: Check that we track states properly, otherwise it wont work. Watch unity board game ep 6 from 30:54
            //theGameState.currentPhase = Monopoly.TurnPhase.DONE_ANIMATING;
        }

    }

    /// <summary>
    /// Sets the new target position of the player.
    /// </summary>
    /// <param name="pos">The position.</param>
    private void SetNewTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
        velocity = Vector3.zero;
        isAnimating = true;
    }

    /// <summary>
    /// Describes the tile that the player is currently on.
    /// </summary>
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

    /// <summary>
    /// Destroys the token.
    /// </summary>
    public void DestroyToken()
    {
        Destroy(gameObject);
    }



    // Update is called once per frame
    //TODO: Animated dice display drop along when smoothdamp.y is set to 0 (Contained in second if statement
    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update()
    {
        if (isAnimating == false)
        {
            return;
        }

        if (Vector3.Distance(new Vector3(this.transform.position.x, targetPosition.y, this.transform.position.z), targetPosition) < smoothDistance)
        {
            //Reached target, need to check height.
            //If heighter than smoothing distance for animation, drop to zero.
            //Otherwise, move to next tile in queue.
            if (moveQueue != null && moveQueueIndex == moveQueue.Length && this.transform.position.y > smoothDistance)
            {
                this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(this.transform.position.x, 0, this.transform.position.z), ref velocity, smoothTime);
            }
            else
            {
                AdvanceMoveQueue();
            }
        }
        //Rise token up before traversing board.
        else if (this.transform.position.y < (smoothHeight - smoothDistance))
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(this.transform.position.x, smoothHeight, this.transform.position.z), ref velocity, smoothTime);
            //traverse board.
        }
        else
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(targetPosition.x, smoothHeight, targetPosition.z), ref velocity, smoothTime);
        }
    }

    /// <summary>
    /// Gets the current tile that the player is on.
    /// </summary>
    /// <returns>Tile.</returns>
    public Tile getCurrentTile()
    {
        return currentTile;
    }

    /// <summary>
    /// Gets the roll that was just rolled.
    /// </summary>
    /// <returns>System.Int32[].</returns>
    public int[] GetCurrentRoll()
    {
        return diceRoller.GetRoll();
    }


    /// <summary>
    /// The player gains this amount of money.
    /// </summary>
    /// <param name="bChange">The change in balance.</param>
    public void Earns(int bChange)
    {
        balance += bChange;
    }

    /// <summary>
    /// The player loses this amount of money.
    /// </summary>
    /// <param name="bChange">The negative balance change.</param>
    public void Spends(int bChange)
    {
        balance -= bChange;
    }

    /// <summary>
    /// Gets the player's current balance.
    /// </summary>
    /// <returns>System.Int32.</returns>
    public int getBalance()
    {
        return balance;
    }

    /// <summary>
    /// Buys the tile the player is currently on.
    /// </summary>
    /// <param name="purchase">The purchased tile.</param>
    public void BuyTile(Purchasable purchase)
    {
        purchase.GetsBoughtBy(this);
        boughtProperties.Add(purchase);
    }

    /// <summary>
    /// Sells a specific tile tile.
    /// </summary>
    /// <param name="sale">The sold tile.</param>
    public void SellTile(Purchasable sale)
    {
        sale.SellsProperty();
        boughtProperties.RemoveAll(z => z == sale);
    }

    /// <summary>
    /// Returns the number of properties the player owns in the street.
    /// </summary>
    /// <param name="cStreet">The colour of the street.</param>
    /// <returns>System.Int32.</returns>
    public int OwnsNoStreet(Street cStreet)
    {
        int count = 0;
        for (int i = 0; i < boughtProperties.Count; i++)
        {
            if (boughtProperties[i].GetStreet() == cStreet)
            {
                count++;
            }
        }
        return count;
    }

    /// <summary>
    /// The player is sent to jail.
    /// </summary>
    public void GoesToJail()
    {
        inJail = true;
        currentTile = Monopoly.tiles[10];
    }

    /// <summary>
    /// Released from jail.
    /// </summary>
    public void ReleasedFromJail()
    {
        inJail = false;
    }

    /// <summary>
    /// Determines whether the player is in jail.
    /// </summary>
    /// <returns><c>true</c> if [is in jail]; otherwise, <c>false</c>.</returns>
    public bool IsInJail()
    {
        return inJail;
    }

    /// <summary>
    /// Gains an opportunity to get out of the jail for free.
    /// </summary>
    public void GetsJailFree()
    {
        jailFree++;
    }

    /// <summary>
    /// Player uses a jail free card.
    /// </summary>
    public void UsesJailFree()
    {
        if (jailFree > 0)
        {
            jailFree--;
            ReleasedFromJail();
        }
    }

    /// <summary>
    /// Gets the number of houses that the player owns.
    /// </summary>
    /// <returns>System.Int32.</returns>
    public int GetNumberOfHouses()
    {
        int count = 0;
        for (int i = 0; i < boughtProperties.Count; i++)
        {
            Purchasable pur = boughtProperties[i];
            if (pur.GetType() == typeof(Property))
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

    /// <summary>
    /// Gets the number of hotels that the player owns.
    /// </summary>
    /// <returns>System.Int32.</returns>
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
                    count++;
                }
            }
        }
        return count;
    }

    /// <summary>
    /// Mortgages the property specified.
    /// </summary>
    /// <param name="i">The property in the player's possession</param>
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
