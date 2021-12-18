using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMotor : MonoBehaviour
{
    public GameObject magic;
    private bool isMagic=false;
    // Start is called before the first frame update
    void Start()
    {
        magic.SetActive(isMagic);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            isMagic = !isMagic;
            //Debug.Log(isMagic);
        }
        magic.SetActive(isMagic);
    }
}
