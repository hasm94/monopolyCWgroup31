// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Displays the view for the current player</summary>
// ***********************************************************************
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class CurrentPlayerDisplay.
/// </summary>
public class CurrentPlayerDisplay : MonoBehaviour
{


    /// <summary>
    /// The game state
    /// </summary>
    Monopoly theGameState;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
    {
        theGameState = GameObject.FindObjectOfType<Monopoly>();
    }

    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update()
    {
        GetComponent<Text>().text = "Player: Player" + (theGameState.currentPlayerId + 1);
    }
}
