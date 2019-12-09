using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

    public float explosiveRange;
    public float explosiveForce;
    public GameObject explosionPrefab;

    private Transform ObjectToExplodeTransform;

	void Start () {

        ObjectToExplodeTransform = this.gameObject.transform;

	
	}
	

	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ExplodeObject();
        }
    }



    void ExplodeObject()
    {

        Collider[] objectsToPush = Physics.OverlapSphere(ObjectToExplodeTransform.position, explosiveRange);

        for (int currentObject = 0; currentObject < objectsToPush.Length; currentObject++)
        {
            Rigidbody currentRigidbody = objectsToPush[currentObject].GetComponent<Rigidbody>();

            if (currentRigidbody != null)
            {
                Vector3 pushAwayVector = currentRigidbody.GetComponent<Transform>().position - ObjectToExplodeTransform.position;
                pushAwayVector.Normalize();
                pushAwayVector *= explosiveForce;
                currentRigidbody.AddForce(pushAwayVector, ForceMode.Impulse);

            }

        }
        GameObject newExplosion;
        newExplosion = Instantiate(explosionPrefab,gameObject.transform.position,Quaternion.identity) as GameObject;


        Destroy(gameObject);

    }

}
