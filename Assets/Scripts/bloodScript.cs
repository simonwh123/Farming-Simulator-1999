using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodScript : MonoBehaviour
{
    public Material[] bloodMaterials;

    private void Start()
    {
        GetComponent<MeshRenderer>().material = bloodMaterials[Random.Range(0, bloodMaterials.Length)];
    }
}
