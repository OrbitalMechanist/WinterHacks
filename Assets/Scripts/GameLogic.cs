using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static int width = 50;
    public static int height = 25;
    public static float cellSize = 16f;

    public Tile[,] grid = new Tile[width + 1, height + 1];
    public float moveCooldown = 3f;
    public bool canMove = true;

    public void TriggerContents()
    {
        foreach(Tile tile in grid)
        {
            if (tile != null)
            {
                tile.TriggerSimulation();
            }
        }

        foreach (Tile tile in grid)
        {
            if (tile != null)
            {
                tile.TriggerCycle();
            }
        }
    }

    public bool IsGridLocEnterable(int x, int y)
    {
        // Out of bounds
        if ((x < 0 || y < 0) || (x > width || y > height))
        {
            return false;
        }
        if (grid[x, y] == null)
        {
            return true;
        }
        BaseBlock target = grid[x, y].GetCurrentState();
        if (target == null)
        {
            return true;
        }
        return !target.IsBlocking();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && canMove)
        {
            canMove = false;
            TriggerContents();
            StartCoroutine(MoveCooldown());
        }
    }

    // Move this enumerator to the movement handler later
    IEnumerator MoveCooldown()
    {
        yield return new WaitForSeconds(moveCooldown);
        canMove = true;
    }
}
