using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int xPos;
    public int yPos;

    private bool frozen = false;

    [SerializeField] private BaseBlock[] _states;
    private GameLogic _gameLogic;
    private BaseBlock _currentState;
    private int _stateIndex = 0;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _gameLogic = FindObjectOfType<GameLogic>();
        _transform = this.transform;
        _currentState = Instantiate(_states[_stateIndex]);

        xPos = Mathf.RoundToInt(_transform.position.x / GameLogic.cellSize);
        yPos = Mathf.RoundToInt(_transform.position.y / GameLogic.cellSize);
        _gameLogic.grid[xPos, yPos] = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TriggerSimulation()
    {
        // Physics like falling
    }

    public void TriggerCycle()
    {
        if (!IsFrozen())
        {
            // Increment the state
            IncrementState();
            // Replace the block
            ReplaceBlock();
        }
    }

    public bool IsFrozen()
    {
        return frozen;
    }

    private void IncrementState()
    {
        _stateIndex = (_stateIndex + 1) % _states.Length;
    }

    private void ReplaceBlock()
    {
        // Destroy the previous state
        Destroy(_currentState);

        // Instantiate a new state and cache it
        _currentState = Instantiate(_states[_stateIndex]);
    }
}
