using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject bloodEffectPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameManager.instance.success = true;
            GameObject MakeBlood;
            MakeBlood = Instantiate(bloodEffectPrefab, gameObject.transform.position + (Vector3.up * 2), Quaternion.identity) as GameObject;

            Destroy(gameObject);
        }
    }
}
