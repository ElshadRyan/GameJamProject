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
    [SerializeField] private GameObject cillinderBeat;
    

    private enum State
    {
        None,
        Green,
        Red,
    }

    private float deltaCap = 1f;
    private float timingAdd;
    private float timingEnd;
    private float timeDelta = 0f;
    private bool green = false;
    private State state;
    private PlayerMove player;
    

    private void Start()
    {
        timingAdd = 0f;
        timingEnd = .5f;
        state = State.None;
        cillinderBeat.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        TimingSwitch();
        timeDelta = timingCap - timingAdd;
        if(timeDelta <= deltaCap)
        {
            cillinderBeat.gameObject.SetActive(true);
        }

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
                    Destroy(gameObject);
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
                Destroy(gameObject);
            }
            if(!green)
            {

                Destroy(gameObject);
            }
        }
    }
}
