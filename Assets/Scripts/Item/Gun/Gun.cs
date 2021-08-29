using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Gun : Item
{
    [SerializeField] Camera cam;

    public GameObject bulletImpactPrefab;
    public Stats player;

    PhotonView PV;

    public float impactForce = 30f;
    public float range = 100f;
    public float fireRate = 0.3f;
    public bool IsMultyShotGun = false;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        StartCoroutine("FireDelay");
    }

    IEnumerator FireDelay()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && (IsMultyShotGun))
            {
                Shoot();
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    public override void Use()
    {
        Shoot();

        if (player.ammo > 0)
        {
            Shoot();
            player.ammo--;
            player.UpdateStats();
        }
    }


    void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            GameObject Target = hit.collider.gameObject;
            if (Target.GetComponentInParent<FirstPersonPlayer>())
            {
                if (Target.GetComponentInParent<FirstPersonPlayer>().photonView.IsMine)
                {
                    return;
                }
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            Target.GetComponentInParent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
            Target.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
            PV.RPC("RPC_Shoot", RpcTarget.All, hit.point, hit.normal);
        }
    }

    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition, Vector3 hitNormal)
    {
        Collider[] colliders = Physics.OverlapSphere(hitPosition, 0.3f);
        if (colliders.Length != 0)
        {
            GameObject bulletImpactObj = Instantiate(bulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * bulletImpactPrefab.transform.rotation);
            Destroy(bulletImpactObj, 10f);
            bulletImpactObj.transform.SetParent(colliders[0].transform);

            GameObject obj = Instantiate(bulletImpactPrefab, hitPosition + hitNormal * 0.001f, Quaternion.LookRotation(hitNormal, Vector3.up) * bulletImpactPrefab.transform.rotation);
            Destroy(obj, 0.2f);

        }
    }
}
