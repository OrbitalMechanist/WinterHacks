using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static int width = 50;
    public static int height = 25;
    public static float cellSize = 16f;

    public Tile[,] grid = new Tile[width, height];

    void TriggerContents()
    {
        foreach(Tile tile in grid){
            tile.TriggerSimulation();
        }
        foreach (Tile tile in grid){
            tile.TriggerCycle();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
