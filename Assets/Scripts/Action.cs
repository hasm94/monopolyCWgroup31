public class Action
{
    private int type;
    private int value;
    private int value2;

    public Action(int t)
    {
        type = t;
    }

    public Action(int t, int val)
    {
        type = t;
        value = val;
    }

    public Action(int t, int val, int val2)
    {
        type = t;
        value = val;
        value2 = val2;
    }

    public void CompleteAction(Player p)
    {
        switch(type)
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
                //Make the player move forward
                break;
            case 5:
                //Make the player move immediately
                break;
            case 6:
                //Have option to choose between two actions
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