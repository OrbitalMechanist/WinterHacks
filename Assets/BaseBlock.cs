using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{

    private bool blocking = false;
    private PlayGrid ownerGrid;
    private int XLoc;
    private int YLoc;

    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        ownerGrid = FindObjectOfType<PlayGrid>();
        _transform = transform;
        // Manipulate with _transform.position += / -= new Vector3(x, y, 0);
        // Change this as well in the playgrid because we are tracking that
        // Access the cell array through the ownerGrid, ownerGrid.cells[,]
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
