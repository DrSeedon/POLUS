using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    public Rigidbody rb;
    public Transform target;
    public float speed;
    public Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTarget();
        rb.AddForce(vec * speed, ForceMode.Force);
    }
    void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(new Vector3(0,10,0), ForceMode.Impulse);
    }

    void CalculateTarget()
    {
        vec = target.position - transform.position;
        vec.y = 0;
    } 
}
