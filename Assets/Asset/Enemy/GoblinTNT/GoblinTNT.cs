using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GoblinTNT : MonoBehaviour
{
    public GameObject TNT;
    // Start is called before the first frame update
    void ThrowDynamite()
    {
        Instantiate(TNT, transform.position , Quaternion.identity);    
    }
}
