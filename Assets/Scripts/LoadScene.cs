using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public Dropdown dropDown;

    void Start()
    {
        dropDown = GameObject.FindObjectOfType<Dropdown>();
    }

    public void LoadByIndex(int sceneIndex)
    {

        PlayerPrefs.SetInt("noPlayers", dropDown.value);
        SceneManager.LoadScene(sceneIndex);
    }
}
