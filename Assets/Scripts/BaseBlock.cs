using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    [SerializeField] private bool blocking = false;
    [SerializeField] private bool hazard = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public bool IsBlocking()
    {
        return blocking;
    }

    public bool IsHazard()
    {
        return hazard;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
