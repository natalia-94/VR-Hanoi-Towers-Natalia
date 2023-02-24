using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskOrderEvaluation : MonoBehaviour
{
    // Verificar que si hay otro disco arriba, no se pueda sacar
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
        double collisionObjectYPosition = collision.gameObject.transform.position.y;
        collision.gameObject.transform.position = new Vector3(this.column.transform.position.x, (float)collisionObjectYPosition, this.column.transform.position.z);
        var found = this.diskList.Find(d => d.name == collision.gameObject.name);
        if (!found) {            
            this.diskList.Add(collision.gameObject);
            //Debug.Log("SE PONE " + collision.gameObject.name);
        }
        EvaluateDisksOrder();
    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("Sale " + collision.gameObject.name);
        if (this.diskList.Count == 0) return;

        int index = this.diskList.FindIndex(d => d.name == collision.gameObject.name);
        if(index != -1)
        {
            this.diskList.RemoveAt(index);
            //Debug.Log("SE QUITA " + collision.gameObject.name);
        } 
    }

    private void EvaluateDisksOrder()
    {
       // Debug.Log("DISCOS: " + this.diskList.Count);
        if (this.diskList.Count < 3) return;

        //Debug.Log("Disco 0:" + this.diskList[0].name + " Disco 1:" + this.diskList[1].name + " Disco 2:" + this.diskList[2].name);

        if (this.diskList[0].name.Equals(bigDisk.name) &&
           this.diskList[1].name.Equals(mediumDisk.name) &&
           this.diskList[2].name.Equals(smallDisk.name))
        {
            //Debug.Log("Ganaste!");
        }
    }

    private void printList(List<GameObject> lista)
    {
        Debug.Log("Size: " + lista.Count);
        lista.ForEach(i =>
        {
            Debug.Log(i.name);
        });
    }
}
