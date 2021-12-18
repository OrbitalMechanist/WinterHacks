using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int xPos;
    public int yPos;

    private bool frozen = false;

    [SerializeField] private GameObject[] _states;
    private GameLogic _gameLogic;
    private GameObject _currentState;
    private int _stateIndex = 0;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _gameLogic = FindObjectOfType<GameLogic>();
        _transform = transform;

        xPos = Mathf.RoundToInt(_transform.position.x);
        yPos = Mathf.RoundToInt(_transform.position.y);

        _currentState = InstantiateState();
        _gameLogic.grid[xPos, yPos] = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TriggerSimulation()
    {
        // Physics like falling
        return;
    }

    public void TriggerCycle()
    {
        if (_states.Length <= 1)
        {
            return;
        }

        if (!IsFrozen())
        {
            // Replace the block
            ReplaceBlock();
        }
    }

    public bool IsFrozen()
    {
     
        return frozen;
    }

    private GameObject InstantiateState()
    {
        return (_states[_stateIndex] == null) ? null : Instantiate(_states[_stateIndex], new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    public BaseBlock GetCurrentState()
    {
        if(_currentState == null)
        {
            return null;
        }
        return _currentState.GetComponent<BaseBlock>();
    }

    private void IncrementState()
    {
        _stateIndex = (_stateIndex + 1) % _states.Length;
    }

    private void ReplaceBlock()
    {
        if (_currentState != null)
        {
            // Destroy the previous state
            Destroy(_currentState);
        }

        // Increment the state index
        IncrementState();

        // Instantiate a new state and cache it
        _currentState = InstantiateState();
    }
}
