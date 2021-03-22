using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanism : MonoBehaviour
{
    //Trigger
    public bool triggerDestroy = false;
    public bool triggerSetMaterial = false;
    public Material material;

    public bool mechDoor = false;
    public float doorSpeed = 1f;
    public Transform doorOpen;
    Vector3 posDoorOpen;
    Quaternion rotDoorOpen;
    Vector3 scaleDoorOpen;
    Vector3 posDoorClose;
    Quaternion rotDoorClose;
    Vector3 scaleDoorClose;
    public bool isDoorOpen = false;

    void OnEnable()
    {
        posDoorClose = transform.position;
        rotDoorClose = transform.rotation;
        scaleDoorClose = transform.localScale;
    }


    void Update()
    {
        if (mechDoor)
        {
            posDoorOpen = doorOpen.position;
            rotDoorOpen = doorOpen.rotation;
            scaleDoorOpen = doorOpen.localScale;
            if (isDoorOpen)
            {
                transform.position = Vector3.Lerp(transform.position, posDoorOpen, Time.deltaTime * doorSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotDoorOpen, Time.deltaTime * doorSpeed);
                transform.localScale = Vector3.Lerp(transform.localScale, scaleDoorOpen, Time.deltaTime * doorSpeed);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, posDoorClose, Time.deltaTime * doorSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotDoorClose, Time.deltaTime * doorSpeed);
                transform.localScale = Vector3.Lerp(transform.localScale, scaleDoorClose, Time.deltaTime * doorSpeed);
            }
        }
    }

    public void Trigger()
    {
        Debug.Log(this.gameObject.name + " активирован");
        if (triggerDestroy)
            Destroy(this.gameObject);
        if (triggerSetMaterial)
            this.GetComponent<MeshRenderer>().material = material;
        if (mechDoor)
        {
            isDoorOpen = !isDoorOpen;
        }
    }
}
