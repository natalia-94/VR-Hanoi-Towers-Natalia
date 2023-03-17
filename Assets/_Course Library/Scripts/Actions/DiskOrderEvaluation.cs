using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiskOrderEvaluation : MonoBehaviour
{
    // Verificar que si hay otro disco arriba, no se pueda sacar [X]
    // Desplegar un UI de Ganaste al apilar los discos de manera correcta
    // Establecer un temporizador con 30 seg.
    // Mostrar UI con los movimiento por default

    [Tooltip("The big size disk")]
    public GameObject bigDisk;

    [Tooltip("The medium size disk")]
    public GameObject mediumDisk;

    [Tooltip("The small size disk")]
    public GameObject smallDisk;

    //private int defaultTries; // 2^n - 1
    private List<GameObject> diskList;
    private GameObject column;

    // Start is called before the first frame update
    void Start()
    {
        this.column = this.gameObject;
        this.diskList = new List<GameObject>();
        //this.defaultTries = 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (WelcomeRestartCanvasActive()) return;

        double collisionObjectYPosition = collision.gameObject.transform.position.y;
        collision.gameObject.transform.position = new Vector3(this.column.transform.position.x, (float)collisionObjectYPosition, this.column.transform.position.z);
        var found = this.diskList.Find(d => d.name == collision.gameObject.name);
        if (!found) {            
            this.diskList.Add(collision.gameObject);
        }
        EvaluateDisksOrder();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (this.diskList.Count == 0) return;

        int index = this.diskList.FindIndex(d => d.name == collision.gameObject.name);
        if(index != -1)
        {
            this.diskList.RemoveAt(index);
        } 
    }

    private void EvaluateDisksOrder()
    {
        if (this.diskList.Count < 3) return;        

        if (this.diskList[0].name.Equals(bigDisk.name) &&
           this.diskList[1].name.Equals(mediumDisk.name) &&
           this.diskList[2].name.Equals(smallDisk.name))
        {
            DisplayWinCanvas();
            ActivateControllRays();
        }
    }

    private void ActivateControllRays()
    {
        GameObject rightHandRay = GameObject.Find("RightHand Ray");
        GameObject leftHandRay = GameObject.Find("LeftHand Ray");
        ToggleRay toggleRayRight = rightHandRay.GetComponent<ToggleRay>();
        ToggleRay toggleRayLeft = leftHandRay.GetComponent<ToggleRay>();

        toggleRayRight.ActivateRay();
        toggleRayLeft.ActivateRay();
    }

    private void DisplayWinCanvas()
    {
        GameObject canvasWin = GameObject.Find("Canvas_Win");
        ToggleInterface toggleInterface = canvasWin.GetComponent<ToggleInterface>();
        toggleInterface.Toggle();
    }
    
    private bool WelcomeRestartCanvasActive()
    {
        bool active = false;
        GameObject welcomeBackground = GameObject.Find("Welcome_Background");
        GameObject resetBackground = GameObject.Find("Reset_Background");

        if (welcomeBackground != null || resetBackground != null) { 
            active = true; 
        }

        return active;
    }
}
