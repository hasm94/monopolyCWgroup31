/// <summary>
/// Class Card.
/// </summary>
public class Card
{
    /// <summary>
    /// The text on the card
    /// </summary>
    string text;
    /// <summary>
    /// The action to be completed, when the card is drawn.
    /// </summary>
    Action action;

    /// <summary>
    /// Initializes a new instance of the <see cref="Card"/> class.
    /// </summary>
    /// <param name="txt">The text.</param>
    /// <param name="act">The action.</param>
    public Card(string txt, Action act)
    {
        text = txt;
        action = act;
    }

    /// <summary>
    /// Completes the action.
    /// </summary>
    /// <param name="p">The player who is the focus.</param>
    public void CompleteAction(Player p)
    {
        action.CompleteAction(p);
    }

    /// <summary>
    /// Gets the text on the card.
    /// </summary>
    /// <returns>System.String.</returns>
    public string getText()
    {
        return text;
    }

}