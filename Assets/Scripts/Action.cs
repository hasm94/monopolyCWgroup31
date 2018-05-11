// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>A specific action that can be linked to a card</summary>
// ***********************************************************************
/// <summary>
/// Class Action.
/// </summary>
public class Action
{
    /// <summary>
    /// The type of action
    /// </summary>
    private int type;
    /// <summary>
    /// The first value, commonly used
    /// </summary>
    private int value;
    /// <summary>
    /// The 2nd value, only used on hotel and house cleaning cards
    /// </summary>
    private int value2;

    /// <summary>
    /// Initializes a new instance of the <see cref="Action"/> class.
    /// </summary>
    /// <param name="t">The type of action.</param>
    public Action(int t)
    {
        type = t;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Action"/> class.
    /// </summary>
    /// <param name="t">The type of action.</param>
    /// <param name="val">The value required.</param>
    public Action(int t, int val)
    {
        type = t;
        value = val;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Action"/> class.
    /// </summary>
    /// <param name="t">The type of action.</param>
    /// <param name="val">The value required.</param>
    /// <param name="val2">The 2nd value of the action.</param>
    public Action(int t, int val, int val2)
    {
        type = t;
        value = val;
        value2 = val2;
    }

    /// <summary>
    /// Completes the action. Depending on type and value
    /// </summary>
    /// <param name="p">The p.</param>
    public void CompleteAction(Player p)
    {
        switch (type)
        {
            case 1:
                p.Earns(value);
                break;
            case 2:
                p.Spends(value);
                break;
            case 3:
                p.Spends(value);
                Monopoly.freeParkingVal += value;
                break;
            case 4:
                // Make the player move forward
                break;
            case 5:
                // Make the player move immediately
                break;
            case 6:
                // Have option to choose between two actions
                break;
            case 7:
                for (int i = 0; i < Monopoly.players.Length; i++)
                {
                    Monopoly.players[i].Spends(value);
                    p.Earns(value);
                }
                break;
            case 8:
                p.GoesToJail();
                break;
            case 9:
                p.GetsJailFree();
                break;
            case 10:
                int houses = p.GetNumberOfHouses();
                int hotels = p.GetNumberOfHotels();
                p.Spends((value * houses) + (hotels * value2));
                break;
        }
    }

}