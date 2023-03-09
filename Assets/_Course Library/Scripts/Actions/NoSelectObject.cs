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
        double currentDiskY = this.gameObject.transform.position.y;
        double colliderY = collision.collider.transform.position.y;
        Debug.Log("Objeto current: " + this.gameObject.name + "\nPositionY:" + currentDiskY + "\n Objeto que llega: " + collision.gameObject.name + "\nPositionY:" + colliderY);

        if (colliderLayer == 3 && (currentDiskY < colliderY)) {
            this.gameObject.layer = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    public void verify() { 
        
    }


}
