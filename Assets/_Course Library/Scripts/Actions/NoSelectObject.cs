using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSelectObject : MonoBehaviour
{
    [Tooltip("disco")]
    public GameObject disk;

    //private string noGrabTag = "Untagged";
    private int noGrabLayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        int colliderLayer = collision.gameObject.layer;
        Debug.Log("Colision con: " + collision.gameObject.name + " Layer: " + colliderLayer);
        double colliderY = collision.collider.transform.position.y;
        if (colliderLayer == 3) {
            //Component xrGrab = 
            
            Debug.Log("GameObject:" + this.gameObject.name + " Layer:" + this.gameObject.layer);
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    public void verify() { 
        
    }


}
