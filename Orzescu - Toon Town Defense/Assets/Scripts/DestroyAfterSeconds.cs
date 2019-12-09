using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

    public float timeToDestroy;

    void Update () {

        Destroy(gameObject, timeToDestroy);
   
	}
}
