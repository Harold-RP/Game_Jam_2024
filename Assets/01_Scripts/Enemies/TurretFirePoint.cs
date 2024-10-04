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

    void Shoot(GameObject bulletPrefab, TurretType type)
    {
        if (type == TurretType.CrazyFire)
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        }
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
