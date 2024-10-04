using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 7f;
    public float lifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        Collider c = GetComponent<Collider>();
        c.enabled = false;
        StartCoroutine(SetColliderOn(c));
    }

    IEnumerator SetColliderOn(Collider c)
    {
        yield return new WaitForSeconds(0.5f);
        c.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
