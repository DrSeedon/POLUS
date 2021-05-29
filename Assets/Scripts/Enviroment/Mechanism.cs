using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanism : MonoBehaviour
{
    //Trigger
    public bool triggerDestroy = false;
    public bool triggerSetMaterial = false;
    public Material material;

    //Door
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

    //Lava
    public bool mechLava = false;
    public float lavaDamage = 10f;
    public float lavaDamageRate = 15f;
    private float nextTimeDamageLava = 0f;

    //Stats
    public bool mechStats = false;
    public float healthAdd = 100f;

    void OnEnable()
    {
        posDoorClose = transform.position;
        rotDoorClose = transform.rotation;
        scaleDoorClose = transform.localScale;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (mechLava)
        {
            Debug.Log(collision.gameObject.name);
            Stats target = collision.transform.GetComponent<Stats>();            
            if (target != null)
            {
                if (Time.time >= nextTimeDamageLava)
                {
                    Debug.Log("mechLava");
                    nextTimeDamageLava = Time.time + 1f / lavaDamageRate;
                    target.health -= lavaDamage;
                    target.UpdateStats();
                }
            }
            
        }
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

    public void Trigger(GameObject player)
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
        if (mechStats)
        {
            player.GetComponent<Stats>().health += healthAdd;
            if (player.GetComponent<Stats>().health > 200f)
            {
                player.GetComponent<Stats>().health = 200f;
            }
            player.GetComponent<Stats>().UpdateStats();
        }
    }
}
