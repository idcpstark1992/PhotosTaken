using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColorChanger : MonoBehaviour
{

    [SerializeField] ColorSelector _colorSelector;
    MeshRenderer _meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        _meshRenderer.material.color = _colorSelector.GetColor();
    }
}
