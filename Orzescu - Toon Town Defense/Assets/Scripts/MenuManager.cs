using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance;

    public Canvas GUICanvas;
    public Canvas startMenu;
    public Canvas instructionsMenu;
    public Canvas winMenu;
    public Canvas loseMenu;



	void Start () {

        instance = this;
        BackToMainMenu();

	}
	
    public void StartGame()
    {
        GameManager.instance.failure = false;
        GUICanvas.enabled = true;
        startMenu.enabled = false;
        GameManager.instance.Player.SetActive(true);


    }

    public void BackToMainMenu()
    {
        
        startMenu.enabled = true;
        GUICanvas.enabled = false;
        instructionsMenu.enabled = false;
        winMenu.enabled = false;
        loseMenu.enabled = false;
    }

    public void SeeInstructions()
    {
        startMenu.enabled = false;
        instructionsMenu.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
