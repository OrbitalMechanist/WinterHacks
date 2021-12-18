using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static int width = 50;
    public static int height = 25;
    public static float cellSize = 16f;

    public Tile[,] grid = new Tile[width, height];
    public float moveCooldown = 3f;
    public bool canMove = true;

    void TriggerContents()
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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if (moved && canMove), CHECK FOR MOVEMENT HERE
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
