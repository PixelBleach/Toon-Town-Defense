using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public float howFastForceIncreases;
    public float clipSize;
    public float minZoom = 60f;
    public float maxZoom = 10f;
    public float zoomIncrement;
    public Camera scopeZoom;

    public MeshRenderer gunModel;

    [Range(10,60)]
    private float currentZoom;
    private float bulletsInClip;
    private float firingForce;

    private Shoot Shooter;
    private bool canFire;
    private bool isZoom;

	// Use this for initialization
	void Start () {

        canFire = true;
        Shooter = gameObject.GetComponent<Shoot>();
        bulletsInClip = clipSize;
        scopeZoom.fieldOfView = 60;
        currentZoom = 60;
        Debug.Log("Current zoom = " + currentZoom);

    }

    // Update is called once per frame
    void Update() {

        Debug.Log("Current zoom = " + currentZoom);

        if (isZoom == false)
        {
            scopeZoom.fieldOfView = 60;
        }


        if (canFire == true) { 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                firingForce += howFastForceIncreases;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Shooter.ShootBullet(firingForce);
                firingForce = 0;
                bulletsInClip -= 1;
                if (bulletsInClip <= 0)
                {
                    canFire = false;
                }
            }
        } else {

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                GUIManager.instance.NeedToReloadText.enabled = true;
                GUIManager.instance.NeedToReloadText.canvasRenderer.SetAlpha(1.0f);
                GUIManager.instance.NeedToReloadText.CrossFadeAlpha(0.0f, 2.0f, false);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                canFire = true;
                bulletsInClip = clipSize;
                GUIManager.instance.ReloadingText.enabled = true;
                GUIManager.instance.ReloadingText.canvasRenderer.SetAlpha(1.0f);
                GUIManager.instance.ReloadingText.CrossFadeAlpha(0.0f, 2.0f, false);
            }

        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            isZoom = true;
            gunModel.enabled = false;
            GUIManager.instance.ZoomScope.enabled = true;
            currentZoom -= (Input.GetAxis("Mouse ScrollWheel") * zoomIncrement);

            if (isZoom == true)
            {
                scopeZoom.fieldOfView = currentZoom;
                if(currentZoom > minZoom)
                {
                    currentZoom = minZoom;
                }
                if(currentZoom < maxZoom)
                {
                    currentZoom = maxZoom;
         
                }

            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            gunModel.enabled = true;
            isZoom = false;
            GUIManager.instance.ZoomScope.enabled = false;
        }

        GUIManager.instance.BulletCountText.text = bulletsInClip.ToString();

    }
}
