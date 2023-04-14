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
    [SerializeField] private Transform buttonTransform;
    

    private enum State
    {
        None,
        Green,
        Red,
    }

    private float timingAdd;
    private float timingEnd;
    private bool green = false;
    private State state;
    

    private void Start()
    {
        timingAdd = 0f;
        timingEnd = 1f;
        state = State.None;

    }

    private void Update()
    {
        
        TimingSwitch();
        
        Debug.Log(state);

    }
    private void TimingSwitch()
    {
        switch (state)
        {
            case State.None:
                if (timingAdd < timingCap)
                {
                    timingAdd += Time.deltaTime;
                }
                else if (timingAdd >= timingCap)
                {
                    timingAdd = 0f;
                    buttonMeshRenderer.material = greenMaterial;
                    state = State.Green;
                    green = true;
                }
                break;
            case State.Green:
                if (timingAdd < timingEnd)
                {
                    timingAdd += Time.deltaTime;
                }
                else if (timingAdd >= timingEnd)
                {
                    timingAdd = 0f;
                    buttonMeshRenderer.material = redMaterial;
                    state = State.Red;
                }
                break;
            case State.Red:
                if (timingAdd < timingEnd)
                {
                    timingAdd += Time.deltaTime;
                }
                else if (timingAdd >= timingEnd)
                {
                    buttonTransform.transform.position = new Vector3(100, 0, 0);
                }
                break;

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(green)
            {
                buttonTransform.transform.position = new Vector3(100, 0, 0);
            }
            if(!green)
            {
                buttonTransform.transform.position = new Vector3(100, 0, 0);
            }
        }
    }
}
