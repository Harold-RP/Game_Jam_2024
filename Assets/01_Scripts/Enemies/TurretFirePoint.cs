using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFirePoint : MonoBehaviour
{
    void OnEnable()
    {
        GetComponentInParent<Turret>()?.onShoot.AddListener(Shoot);
    }

    void OnDisable()
    {
        GetComponentInParent<Turret>()?.onShoot.RemoveListener(Shoot);
    }

    void Shoot(GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
