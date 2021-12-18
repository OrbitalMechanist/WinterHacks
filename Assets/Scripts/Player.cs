using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int xPos;
    public int yPos;

    public GameLogic logic;

    public void MoveRight()
    {
        if (logic.grid[xPos + 1, yPos] == null)
        {
            xPos++;
        } else if(!logic.grid[xPos + 1, yPos].GetCurrentState().IsBlocking())
        {
            xPos++;
        }
        UpdatePositionDisplay();
    }

    public void MoveLeft()
    {
        if (logic.grid[xPos - 1, yPos] == null)
        {
            xPos--;
        } else if (!logic.grid[xPos - 1, yPos].GetCurrentState().IsBlocking())
        {
            xPos--;
        }
        UpdatePositionDisplay();
    }

    public void UpdatePositionDisplay()
    {
        transform.position = new Vector2(xPos, yPos);
    }

    private GameLogic _gameLogic;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _gameLogic = FindObjectOfType<GameLogic>();
        _transform = transform;

        xPos = Mathf.RoundToInt(_transform.position.x);
        yPos = Mathf.RoundToInt(_transform.position.y);
    }

    private void OnMove(InputValue val)
    {
        if((Vector2)val.Get() == Vector2.right){
            Debug.Log("R");
            MoveRight();
            return;
        }
        if ((Vector2)val.Get() == Vector2.left)
        {
            Debug.Log("L");
            MoveLeft();
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
