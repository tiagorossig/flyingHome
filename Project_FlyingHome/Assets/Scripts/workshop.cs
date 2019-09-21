using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workshop : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vextor3(1f, 0f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //Runs after a specific amounnt of frames
    }
}
