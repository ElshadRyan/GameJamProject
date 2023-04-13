using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;
    [SerializeField] private MeshRenderer buttonMeshRenderer;

    private void OnTriggerEnter(Collider other)
    {
        buttonMeshRenderer.material = redMaterial;
    }
}
