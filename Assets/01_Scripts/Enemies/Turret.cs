using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public UnityEvent<GameObject, TurretType> onShoot;
    public float timer = 0f;
    public float timeBtwShoot = 0.5f;
    public float rotationSpeed = 20f;
    public Transform firePoints;
    public TurretType type;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        GameObject targetGo = GameObject.FindGameObjectWithTag("Player");
        if (targetGo != null)
        {
            target = targetGo.transform;
        }
        if (type == TurretType.CrazyFire)
        {
            timeBtwShoot = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        switch (type)
        {
            case TurretType.RotatingFire:
                firePoints.Rotate(0, rotationSpeed * Time.deltaTime, 0);
                break;
            case TurretType.TargetFire:
                Vector3 dir = target.position - transform.position;
                float angleY = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                firePoints.rotation = Quaternion.Euler(0, angleY, 0);
                break;
        }
    }

    void Shoot()
    {
        if (timer < timeBtwShoot)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            onShoot?.Invoke(bulletPrefab, type);
        }
    }
}

public enum TurretType
{
    RotatingFire,
    StaticFire,
    CrazyFire,
    TargetFire
}
