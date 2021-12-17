using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGrid : MonoBehaviour
{
    public static int XSize;
    public static int YSize;

    public BaseBlock[,] cells;
    float CellSize;

    public PlayGrid(int x, int y, float size)
    {
        XSize = x;
        YSize = y;
        CellSize = size;

        cells = new BaseBlock[XSize, YSize];
    }

    void TriggerContents()
    {
        foreach(BaseBlock i in cells){
            i.TriggerSimulation();
        }
        foreach (BaseBlock i in cells){
            i.TriggerCycle();
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
