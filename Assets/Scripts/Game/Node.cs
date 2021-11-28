using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private Vector2Int pos;

    public int gCost { get; set; }
    public int hCost { get; set; }
    public int fCost { get; set; }

    public TileType TileType { get; set; }

    public Node pastNode { get; set; }

    public Node(Vector2Int pos, TileType tile)
    {
        this.pos = pos;
        this.TileType = tile;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public Vector2Int GetPos()
    {
        return pos;
    }
}
