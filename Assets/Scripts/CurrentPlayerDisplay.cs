using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerDisplay : MonoBehaviour
{


    Monopoly theGameState;
    // Use this for initialization
    void Start()
    {
        theGameState = GameObject.FindObjectOfType<Monopoly>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Player: Player" + (theGameState.currentPlayerId + 1);
    }
}
