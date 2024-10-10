using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enredadera : MonoBehaviour
{
    public RectTransform enredaderaUI;
    public float tiempoXEnredadera = 3f;
    float timer = 0f;
    bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                LeanTween.moveY(enredaderaUI, 0, 1f);
            }
            else
            {
                isActive = false;
            }
        }
        else
        {
            LeanTween.moveY(enredaderaUI, -1100, 1f);
        }
    }

    public void ActivarEnredadera()
    {
        timer += tiempoXEnredadera;
        isActive = true;
    }
}
