using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Enumeration for various game states.
/// </summary>
public enum GameState { Menu, Game, Pause };

public class GameManager : MonoBehaviour
{
    // Fields
    public static GameState gameState;

    /// <summary>
    /// Initialize the GameManager.
    /// </summary>
    void Start()
    {
        gameState = GameState.Menu;
    }

    /// <summary>
    /// Perform various operations dependent on game state.
    /// </summary>
    void Update()
    {
        // State Machine
        switch (gameState)
        {
            case GameState.Menu:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Start the game and load the scene
                    gameState = GameState.Game;
                    //SceneManager.LoadScene(sceneName: "SceneName"); // BLOCKER: Need menu scene to start on
                }
                break;
            case GameState.Game:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Pause the game
                    //LevelManager.pauseMenu.SetActive(true); // BLOCKER: Need to discuss pause menu
                    gameState = GameState.Pause;
                }
                break;
            case GameState.Pause:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Unpause the game
                    //LevelManager.pauseMenu.SetActive(false); // BLOCKER: Need to discuss pause menu
                    gameState = GameState.Game;
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    // Return to the menu
                    gameState = GameState.Menu;
                    //SceneManager.LoadScene(sceneName: "Menu"); // BLOCKER: Need menu scene
                }
                break;
        }
    }

    /// <summary>
    /// On object creation, make the GameManager persistant.
    /// </summary>
    void Awake()
    {
        // Make the GameManager persist throughout the game
        DontDestroyOnLoad(this.gameObject);
    }
}
