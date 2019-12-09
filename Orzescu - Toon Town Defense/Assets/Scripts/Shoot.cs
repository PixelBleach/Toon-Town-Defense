using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    [Header("Bullet Properties")]
    public GameObject bulletPrefab;
    public float bulletAliveTime;
    public Transform bulletSpawnPointTransform;
    public float minShootingForce;
    public float maxShootingForce;
    public Transform playerTF;

	// Use this for initialization
	void Start () {

        //playerTF = GameManager.instance.Player.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShootBullet(float firingForce)
    {
        GameObject theBullet;

        Quaternion rotation = playerTF.rotation * Quaternion.Euler(90f,0f,0f);

        theBullet = Instantiate(bulletPrefab, bulletSpawnPointTransform.position + bulletSpawnPointTransform.forward, rotation) as GameObject;

        Rigidbody bulletRigidBody;
        bulletRigidBody = theBullet.GetComponent<Rigidbody>();

        if (firingForce < minShootingForce)
        {
            firingForce = minShootingForce;
        }
        if (firingForce > maxShootingForce)
        {
            firingForce = maxShootingForce;
        }

        bulletRigidBody.AddForce(bulletSpawnPointTransform.forward * firingForce);

        Destroy (theBullet, bulletAliveTime);
    }

}
