public class Card
{
    string text;
    Action action;

    public Card(string txt, Action act)
    {
        text = txt;
        action = act;
    }

    public void CompleteAction(Player p)
    {
        action.CompleteAction(p);
    }

    public string getText()
    {
        return text;
    }

}