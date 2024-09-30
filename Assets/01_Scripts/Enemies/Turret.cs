using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public UnityEvent<GameObject> onShoot;
    public float timer = 0f;
    public float timeBtwShoot = 0.5f;
    public float rotationSpeed = 20f;
    public Transform firePoints;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        firePoints.Rotate(0, rotationSpeed * Time.deltaTime, 0);
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
            onShoot?.Invoke(bulletPrefab);
        }
    }
}
