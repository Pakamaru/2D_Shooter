using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class RoomLayout : MonoBehaviour
{
    private TileType[,] map = new TileType[20, 10];
    private List<Node> nodes = new List<Node>();
    [SerializeField]
    private GameObject wallPref;
    [SerializeField]
    private GameObject waterPref;
    [SerializeField]
    private GameObject spikePref;
    [SerializeField]
    private GameObject doorNextPref;
    [SerializeField]
    private GameObject doorBackPref;
    
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
                            nodes.Add(new Node(new Vector2Int(x, y), TileType.FLOOR));
                            break;
                        case "Wall":
                            Instantiate(wallPref, new Vector3(x - GetBounds().x / 2 + 0.5f, y - GetBounds().y / 2 + 0.5f, transform.position.z), default);
                            map[x, y] = TileType.WALL;
                            break;
                        case "Water":
                            Instantiate(waterPref, new Vector3(x - GetBounds().x / 2 + 0.5f, y - GetBounds().y / 2 + 0.5f, transform.position.z), default);
                            map[x, y] = TileType.WATER;
                            break;
                        case "Spike":
                            Instantiate(spikePref, new Vector3(x - GetBounds().x / 2 + 0.5f, y - GetBounds().y / 2 + 0.5f, transform.position.z), default);
                            map[x, y] = TileType.SPIKE;
                            nodes.Add(new Node(new Vector2Int(x, y), TileType.SPIKE));
                            break;
                        case "Door":
                            if (x > GetBounds().x / 2)
                                Instantiate(doorNextPref, new Vector3(x - GetBounds().x / 2 + 0.5f, y - GetBounds().y / 2 + 0.5f, transform.position.z), default);
                            else
                                Instantiate(wallPref, new Vector3(x - GetBounds().x / 2 + 0.5f, y - GetBounds().y / 2 + 0.5f, transform.position.z), default);
                            map[x, y] = TileType.DOOR;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    public Node GetNode(Vector2Int pos)
    {
        return nodes.Where(n => n.GetPos() == pos).FirstOrDefault();
    }

    public Node GetNode(int x, int y)
    {
        return nodes.Where(n => n.GetPos() == new Vector2Int(x, y)).FirstOrDefault();
    }

    public List<Node> GetNodes()
    {
        return nodes;
    }

    public Vector2Int GetBounds()
    {
        return new Vector2Int(map.GetLength(0), map.GetLength(1));
    }
}
