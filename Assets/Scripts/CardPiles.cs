public static class CardPiles
{
    private static Card[] potLuckPile;
    private static Card[] opportunityKnocksPile;
    private static int plCard;
    private static int okCard;

    static CardPiles()
    {
        plCard = 0;
        okCard = 0;
    }

    public static void TakePLCard(Player p)
    {
        potLuckPile[plCard].CompleteAction(p);
        if (plCard == 16)
        {
            plCard = 0;
        } else {
            plCard++;
        }
    }

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

    public static void SetPLCards(Card[] cards)
    {
        potLuckPile = cards;
    }

    public static void SetOKCards(Card[] cards)
    {
        opportunityKnocksPile = cards;
    }

}