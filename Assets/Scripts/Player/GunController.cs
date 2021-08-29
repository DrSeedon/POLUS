using UnityEngine;
using Photon.Pun;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public GameObject impactEffect;

    public GameObject player;

    private float nextTimeToFire = 0f;
    public PhotonView PV;

    void Update()
    {
        if (!PV.IsMine)
            return;

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;


        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {


            Stats target = hit.transform.GetComponent<Stats>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject obj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Destroy(obj, 0.2f);
        }

    }
}
