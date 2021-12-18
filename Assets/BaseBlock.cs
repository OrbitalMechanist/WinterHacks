using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    //Asdf
    private bool blocking = false;
    private bool frozen = false;
    private PlayGrid ownerGrid;
    private int XLoc;
    private int YLoc;

    [SerializeField] private Transform[] _states;
    private int stateIndex = 0;
    private Transform _currentState;

    // Start is called before the first frame update
    void Start()
    {
        // Get the grid
        ownerGrid = FindObjectOfType<PlayGrid>();

        // Set the initial state to 0
        _currentState = _states[stateIndex];

        // Set the position of the tile
        XLoc = Mathf.RoundToInt(_currentState.position.x/ownerGrid.GetCellSize());
        YLoc = Mathf.RoundToInt(_currentState.position.y/ownerGrid.GetCellSize());

//        _currentState.position.x = XLoc * ownerGrid.GetCellSize();
//        _currentState.position.y = YLoc * ownerGrid.GetCellSize();

        // Set the grid cell to this block
        ownerGrid.cells[XLoc, YLoc] = this;
    }

    private void IncrementState()
    {
        stateIndex = (stateIndex + 1) % _states.Length;
        // Set the new state
        _currentState = _states[stateIndex];
        // Need to replace the sprite and colliders
    }

    public void TriggerSimulation()
    {
        // Not exactly sure what the difference between TriggerSimulation and TriggerCycle is.
    }

    public void TriggerCycle()
    {
        if (!IsFrozen())
        {
            // Increment the state
            IncrementState();
        }
    }

    public bool IsFrozen()
    {
        return frozen;
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
