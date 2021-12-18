using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            return;
        }
        if(!logic.grid[xPos + 1, yPos].GetCurrentState().IsBlocking())
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
            return;
        }
        if (!logic.grid[xPos - 1, yPos].GetCurrentState().IsBlocking())
        {
            xPos--;
        }
        UpdatePositionDisplay();
    }

    public void UpdatePositionDisplay()
    {
        transform.position = new Vector2(xPos, yPos);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {

        }
    }
}
