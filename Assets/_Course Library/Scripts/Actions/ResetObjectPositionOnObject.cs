using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectPositionOnObject : MonoBehaviour
{
    [Tooltip("The transform where the object will be position")]
    public GameObject transformObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Equals("Ground")) return;       

        this.gameObject.transform.position = new Vector3(this.transformObject.transform.position.x, this.transformObject.transform.position.y, this.transformObject.transform.position.z);
    }

}
