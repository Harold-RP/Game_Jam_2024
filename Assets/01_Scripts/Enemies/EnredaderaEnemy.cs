using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnredaderaEnemy : MonoBehaviour
{
    public float speed = 10f;
    public Transform target;
    Vector3 targetDifference;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        GameObject targetGo = GameObject.FindGameObjectWithTag("Player");
        if (targetGo != null)
        {
            target = targetGo.transform;
        }
        targetDifference = target.position - transform.position;
        float angleY = Mathf.Atan2(targetDifference.x, targetDifference.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angleY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enredadera e = other.gameObject.GetComponent<Enredadera>();
            e.ActivarEnredadera();
            Destroy(gameObject);
        }
    }
}
