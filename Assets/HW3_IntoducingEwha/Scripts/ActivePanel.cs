using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePanel : MonoBehaviour
{
    public GameObject panel;
    bool isIn;

    private void Start()
    {
        isIn = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isIn) panel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "My_Robot")
        {
            isIn = true;
            Debug.Log("can open " + panel.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "My_Robot")
        {
            isIn = false;
            Debug.Log("can't open " + panel.name);
        }
    }
}
