using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [HideInInspector]
    public static GameManager instance;
    public int enemiesInScene;
    public bool failure;
    public bool success;

    [Header("Player Data")]
    public GameObject Player;
    public GameObject menuCamera;

	// Use this for initialization
	void Start () {

        success = false;
        instance = this;
        Player.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
	
        if (failure == true)
        {
            MenuManager.instance.loseMenu.enabled = true;
            Player.SetActive(false);

            if (MenuManager.instance.startMenu.enabled == true)
            {
                MenuManager.instance.loseMenu.enabled = false;
                failure = false;
            }

        }

        if (success == true)
        {
            MenuManager.instance.winMenu.enabled = true;
            Player.SetActive(false);

            if (MenuManager.instance.startMenu.enabled == true)
            {
                MenuManager.instance.winMenu.enabled = false;
                success = false;
            }
        }

	}
}
