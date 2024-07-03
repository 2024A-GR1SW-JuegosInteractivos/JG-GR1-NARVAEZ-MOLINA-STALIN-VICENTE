using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    [SerializeField] private GameObject cosaQueQuieroSeguir;
    void LateUpdate()
    {
        transform.position = cosaQueQuieroSeguir.transform.position +
                             new Vector3(0,0,-10);
    }
}