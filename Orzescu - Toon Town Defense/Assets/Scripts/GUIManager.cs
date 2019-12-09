using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public static GUIManager instance;

    public Canvas ZoomScope;
    public Canvas GUICanvas;
    public Text BulletCountText;
    public Text ReloadingText;
    public Text NeedToReloadText;


	// Use this for initialization
	void Start () {

        instance = this;
        ZoomScope.enabled = false;
        ReloadingText.enabled = false;
        NeedToReloadText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
