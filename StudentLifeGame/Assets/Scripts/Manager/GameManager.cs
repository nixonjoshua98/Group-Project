using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public enum GameState { PRE, ACTIVE, POST };

    [HideInInspector]
    public GameState state = GameState.PRE;

    public GameObject startMenu;
    public GameObject gameoverMenu;


    private void Awake()
    {
        instance = this;
    }


    private void FixedUpdate()
    {
        if (state == GameState.POST)
            gameoverMenu.SetActive(true);
    }


    public void StartGame()
    {
        state = GameState.ACTIVE;
        startMenu.SetActive(false);
    }


    public void ExitGame()
    {

    }


    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
