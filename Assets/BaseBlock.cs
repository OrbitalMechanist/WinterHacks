using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{

    private bool blocking = false;
    private PlayGrid ownerGrid;
    private int XLoc;
    private int YLoc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TriggerSimulation()
    {

    }

    public void TriggerCycle()
    {

    }

    public bool IsBlocking()
    {
        return blocking;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
