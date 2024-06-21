using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    [SerializeField] private GameObject objSeguir;
    // Update is called once per frame
   

    void LateUpdate()
    {
        if (objSeguir)
        {
            transform.position = objSeguir.transform.position + new Vector3(0, 0, -10);
        }
        else
        {
        }
    }
}