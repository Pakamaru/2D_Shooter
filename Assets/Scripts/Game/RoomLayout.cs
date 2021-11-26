using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class RoomLayout : MonoBehaviour
{
    private TileType[,] map = new TileType[20, 10];
    private List<Node> nodes = new List<Node>();

    void Start()
    {
        Tilemap tilemap = GetComponentInChildren<Tilemap>();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    switch (tile.name)
                    {
                        case "Floor":
                            map[x, y] = TileType.FLOOR;
                            nodes.Add(new Node(new Vector2Int(x, y)));
                            break;
                        case "Wall": map[x, y] = TileType.WALL;
                            break;
                        case "Water": map[x, y] = TileType.WATER;
                            break;
                        case "Door": map[x, y] = TileType.DOOR;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }
    }

    public TileType[,] GetTiles()
    {
        return map;
    }

    public Node GetNode(Vector2Int pos)
    {
        return nodes.Where(n => n.GetPos() == pos).FirstOrDefault();
    }
    public Node GetNode(float x, float y)
    {
        return nodes.Where(n => n.GetPos() == new Vector2Int(x, y)).FirstOrDefault();
    }

    public List<Node> GetNodes()
    {
        return nodes;
    }
}
