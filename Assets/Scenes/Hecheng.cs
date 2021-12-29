using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hecheng : MonoBehaviour
{
    public GameObject hecheng;
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            bool isOpen = false;
            isOpen = !isOpen;
            hecheng.SetActive(isOpen);
        
        }
    }
}
