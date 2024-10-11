using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("--------------- Stats ---------------")]
    public int score = 0;
    public float life = 100f;
    public float speed = 10f;
    public float runningSpeed = 20f;
    public float attackDamage = 5f;
    public float rotationSpeed = 20f;
    [Header("--------------- References ---------------")]
    public Rigidbody rb;
    public GameObject body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
    }
}
