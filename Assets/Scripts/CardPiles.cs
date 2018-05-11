/// <summary>
/// Class CardPiles.
/// </summary>
public static class CardPiles
{
    /// <summary>
    /// The pot luck pile
    /// </summary>
    private static Card[] potLuckPile;
    /// <summary>
    /// The opportunity knocks pile
    /// </summary>
    private static Card[] opportunityKnocksPile;
    /// <summary>
    /// The potluck card counter
    /// </summary>
    private static int plCard;
    /// <summary>
    /// The opportunity knocks card counter
    /// </summary>
    private static int okCard;

    /// <summary>
    /// Initializes static members of the <see cref="CardPiles"/> class.
    /// </summary>
    static CardPiles()
    {
        plCard = 0;
        okCard = 0;
    }

    /// <summary>
    /// Takes a PotLuck card and executes it.
    /// </summary>
    /// <param name="p">The player drawing the card.</param>
    public static void TakePLCard(Player p)
    {
        potLuckPile[plCard].CompleteAction(p);
        if (plCard == 16)
        {
            plCard = 0;
        }
        else
        {
            plCard++;
        }
    }

    /// <summary>
    /// Takes an opportunity knocks card and executes it.
    /// </summary>
    /// <param name="p">The player drawing</param>
    public static void TakeOKCard(Player p)
    {
        opportunityKnocksPile[okCard].CompleteAction(p);
        if (okCard == 16)
        {
            okCard = 0;
        }
        else
        {
            okCard++;
        }
    }

    /// <summary>
    /// Sets the pot luck cards.
    /// </summary>
    /// <param name="cards">The new card set.</param>
    public static void SetPLCards(Card[] cards)
    {
        potLuckPile = cards;
    }

    /// <summary>
    /// Sets the opportunity knocks cards.
    /// </summary>
    /// <param name="cards">The new card set.</param>
    public static void SetOKCards(Card[] cards)
    {
        opportunityKnocksPile = cards;
    }

}