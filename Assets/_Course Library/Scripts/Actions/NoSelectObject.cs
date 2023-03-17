using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NoSelectObject : MonoBehaviour
{
    //private string noGrabTag = "Untagged";
    private int noGrabLayer = 0;
    private int diskLayer = 2;

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

        if (colliderLayer != 3) return;

        XRGrabInteractable interactor = this.gameObject.GetComponent<XRGrabInteractable>();
        XRGrabInteractable interactorCollision = collision.gameObject.GetComponent<XRGrabInteractable>();

        if (interactor == null || interactorCollision == null) return;
       
        if (currentDiskY < colliderY) {
            
            interactor.interactionLayers = noGrabLayer;
            interactorCollision.interactionLayers = diskLayer;
        }
        else
        {
            interactorCollision.interactionLayers = noGrabLayer;
            interactor.interactionLayers = diskLayer;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        int colliderLayer = collision.gameObject.layer;

        if (colliderLayer != 3) return;

        XRGrabInteractable interactor = this.gameObject.GetComponent<XRGrabInteractable>();
        interactor.interactionLayers = diskLayer;
    }

    public void verify() { 
        
    }


}
