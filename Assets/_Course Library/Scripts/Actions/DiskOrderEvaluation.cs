using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class DiskOrderEvaluation : MonoBehaviour
{
    // Verificar que si hay otro disco arriba, no se pueda sacar [X]
    // Desplegar un UI de Ganaste al apilar los discos de manera correcta
    // Establecer un temporizador con 30 seg.
    // Mostrar UI con los movimiento por default

    [Tooltip("The biggest size disk")]
    public GameObject bigBlue;

    [Tooltip("The medium size disk")]
    public GameObject mediumRed;

    [Tooltip("The medium small disk")]
    public GameObject mediumGreen;

    [Tooltip("The smalles disk")]
    public GameObject smallYellow;

    //private int defaultTries; // 2^n - 1
    private List<GameObject> diskList;
    private GameObject column;
    private string diskTag;

    // Start is called before the first frame update
    void Start()
    {
        this.column = this.gameObject;
        this.diskList = new List<GameObject>();
        this.diskTag = "disk";
        //this.defaultTries = 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (WelcomeRestartCanvasActive()) return;
        if (!collision.gameObject.tag.Equals(this.diskTag)) return;
        
        var found = this.diskList.Find(d => d.name == collision.gameObject.name);
        if (!found)
        {
            this.diskList.Add(collision.gameObject);
            double collisionObjectYPosition = collision.gameObject.transform.position.y;
            collision.gameObject.transform.position = new Vector3(this.column.transform.position.x, (float)collisionObjectYPosition, this.column.transform.position.z);
            Debug.Log("Entra a " + this.column.name + ":" + collision.gameObject.name);
            EvaluateDisksOrder();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (this.diskList.Count == 0) return;

        int index = this.diskList.FindIndex(d => d.name == collision.gameObject.name);
        if (index != -1)
        {
            this.diskList.RemoveAt(index);
            Debug.Log("Sale de " + this.column.name + ":" + collision.gameObject.name);
        }
    }

    public void EvaluateDisksOrder()
    {
        if (this.diskList.Count < 4) return;        

        if (this.diskList[0].name.Equals(bigBlue.name) &&
           this.diskList[1].name.Equals(mediumRed.name) &&
           this.diskList[2].name.Equals(mediumGreen.name) &&
           this.diskList[3].name.Equals(smallYellow.name))
        {
            DisplayWinCanvas();
            this.diskList.Clear();
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
        if (canvasWin == null) return;
        ToggleInterface toggleInterface = canvasWin.GetComponent<ToggleInterface>();
        toggleInterface.Toggle();
        ActivateControllRays();
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
