using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] Scene currentScene;
    bool menu;
    public bool restart;
    [SerializeField] GameObject menuGUI;
    [SerializeField] GameObject playGUI;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject winScreen;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) //Listens for the player to toggle the menu
        {
            menu = !menu;
        }
        if(menu)
        {
            menuGUI.SetActive(true);
            playGUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None; //unlocks the cursor
            Time.timeScale = 0; //pauses the game
        }
        else
        {
            menuGUI.SetActive(false);
            playGUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;   //locks the cursor
            Time.timeScale = 1; //Unpauses the game
        }

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<HitPointPool>().hitPoints<=0)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if(GameObject.FindGameObjectsWithTag("Enemy").Length==0)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
