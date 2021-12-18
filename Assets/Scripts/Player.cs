using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int xPos;
    public int yPos;

    //false is right, true is left
    public bool facing = false;

    public GameLogic logic;

    public void MoveRight()
    {
        facing = false;
        if (logic.IsGridLocEnterable(xPos + 1, yPos))
        {
            xPos++;
            UpdatePositionDisplay();
        }
    }

    public void MoveLeft()
    {
        facing = true;
        if (logic.IsGridLocEnterable(xPos - 1, yPos)) {
            xPos--;
            UpdatePositionDisplay();
        }
    }

    public void Hop()
    {
        int direction = 1;
        if (facing)
        {
            direction = -1;
        }
        bool directAboveClear = logic.IsGridLocEnterable(xPos, yPos + 1);
        bool sideClear = logic.IsGridLocEnterable(xPos + direction, yPos);
        bool aboveSideClear = logic.IsGridLocEnterable(xPos + direction, yPos + 1);
        bool aboveTargetClear = logic.IsGridLocEnterable(xPos + direction*2, yPos + 1);
        bool targetClear = logic.IsGridLocEnterable(xPos + direction*2, yPos);
        if(directAboveClear && sideClear && aboveSideClear && aboveTargetClear && targetClear)
        {
            xPos += direction * 2;
        } else if ( directAboveClear && !sideClear && aboveSideClear)
        {
            xPos += direction;
            yPos++;
        }
        UpdatePositionDisplay();
    }

    public void UpdatePositionDisplay()
    {
        transform.position = new Vector2(xPos, yPos);
    }

    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        logic = FindObjectOfType<GameLogic>();
        if (logic == null)
        {
            Debug.Log("Unable to find GameLogic");
        }

        _transform = transform;

        xPos = Mathf.RoundToInt(_transform.position.x);
        yPos = Mathf.RoundToInt(_transform.position.y);
    }

    private void OnMove(InputValue val)
    {
        if((Vector2)val.Get() == Vector2.right){
            Debug.Log("R");
            MoveRight();
        }else if ((Vector2)val.Get() == Vector2.left)
        {
            Debug.Log("L");
            MoveLeft();
        }else if ((Vector2)val.Get() == Vector2.up)
        {
            Debug.Log("U");
            Hop();
        }
        Fall();
        logic.TriggerContents();
    }

    public void Fall()
    {
        while(logic.IsGridLocEnterable(xPos, yPos - 1))
        {
            Debug.Log("Falling");
            yPos--;
            UpdatePositionDisplay();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
