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

    private GameLogic logic;
    private Transform _transform;
    [SerializeField] private Animator _anim;

    public void MoveRight()
    {
        facing = false;
        _transform.localScale = new Vector3(1f, 1f, 1f);
        if (logic.IsGridLocEnterable(xPos + 1, yPos))
        {
            xPos++;
            UpdatePositionDisplay();
        }
    }

    public void MoveLeft()
    {
        facing = true;
        _transform.localScale = new Vector3(-1f, 1f, 1f);
        if (logic.IsGridLocEnterable(xPos - 1, yPos)) {
            xPos--;
            UpdatePositionDisplay();
        }
    }

    public void Hop()
    {
        int direction = (facing ? -1 : 1);
        bool directAboveClear = logic.IsGridLocEnterable(xPos, yPos + 1);
        bool sideClear = logic.IsGridLocEnterable(xPos + direction, yPos);
        bool aboveSideClear = logic.IsGridLocEnterable(xPos + direction, yPos + 1);
        bool targetClear = logic.IsGridLocEnterable(xPos + direction*2, yPos);
        bool aboveTargetClear = logic.IsGridLocEnterable(xPos + direction*2, yPos + 1);
        if (directAboveClear && sideClear && aboveSideClear && aboveTargetClear)
        {
            if (!targetClear)
            {
                yPos++;
            }
            xPos += direction * 2;
        }
        else if ( directAboveClear && !sideClear && aboveSideClear)
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

    // Null reference here
    private void OnMove(InputValue val)
    {
        Debug.Log(val.ToString());
        if (val == null)
        {
            return;
        }
        if ((Vector2)val.Get() == Vector2.right){
            Debug.Log("R");
            MoveRight();
        }
        else if ((Vector2)val.Get() == Vector2.left)
        {
            Debug.Log("L");
            MoveLeft();
        }
        else if ((Vector2)val.Get() == Vector2.up)
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
