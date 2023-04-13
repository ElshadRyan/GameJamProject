using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : MonoBehaviour
{
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private MeshRenderer buttonMeshRenderer;
    [SerializeField] private float timingCap;
    private float timingAdd;
    private float timingEnd;
    private bool isGreen = false;
    private bool end = false;

    private void Start()
    {
        timingAdd = 0f;
        timingEnd = .5f;
    }

    private void Update()
    {
        
        TimingSwitch();
        
        Debug.Log(timingAdd);

    }
    private void TimingSwitch()
    {
        if (timingAdd < timingCap)
        {
            timingAdd += Time.deltaTime;
        }
        else if (timingAdd >= timingCap && !isGreen)
        {
            timingAdd = 0f;
            buttonMeshRenderer.material = greenMaterial;
            isGreen = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
