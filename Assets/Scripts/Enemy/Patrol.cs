using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : IState
{
    private Enemy enemy;
    private GameObject body;
    private GameObject player;

    float range = 10.0f;
    float roadPassed = 0;
    private int patrolRange;

    // Algorithm
    private TileType[,] map = new TileType[20, 10];
    private RoomLayout roomLayout;

    private List<Node> OpenList;
    private List<Node> closedList;
    private Stack<Node> actualPath;

    private Node startNode;
    private Node endNode;

    private const int STRAIGHT_MOVE_COST = 10;
    private const int DIAGONAL_MOVE_COST = 15;

    private Node targetNode;


    public Patrol(Enemy enemy, int patrolRange, GameObject body, GameObject player, RoomLayout roomLayout)
    {
        this.enemy = enemy;
        this.patrolRange = patrolRange;
        this.body = body;
        this.player = player;
        this.roomLayout = roomLayout;
    }

    public void Tick()
    {
        Move();

        /*
        if (roadPassed < range * 100)
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0 * enemy.CurSpeed, 1 * enemy.CurSpeed);
            roadPassed += 1 * enemy.CurSpeed;
        }
        else
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0 * enemy.CurSpeed, -1 * enemy.CurSpeed);
            roadPassed += 1 * enemy.CurSpeed;
            if (roadPassed > range * 100 * 2)
                roadPassed = 0;
        }
        */
    }

    private void Move()
    {
        if (enemy.GetPos() != targetNode.GetPos())
        {
            Vector2.MoveTowards(enemy.transform.position, targetNode.GetPos(), Time.deltaTime * 5f);
        }
        else
        {
            targetNode = actualPath.Pop();
        }
    }

    private List<Node> FindPath()
    {
        startNode = roomLayout.GetNode((int)enemy.transform.position.x, (int)enemy.transform.position.y);
        endNode = roomLayout.GetNode((int)player.transform.position.x, (int)player.transform.position.y);


        foreach (Node node in roomLayout.GetNodes())
        {
            node.gCost = int.MaxValue;
            node.CalculateFCost();
            node.pastNode = null;
        }

        if (endNode == null) return null;
        OpenList = new List<Node> { startNode };
        closedList = new List<Node>();

        startNode.gCost = 0;
        startNode.hCost = GetCalculatedDistanceCost(startNode.GetPos(), endNode.GetPos());
        startNode.CalculateFCost();

        while (OpenList.Count > 0)
        {
            Node cur = GetLowestFCost(OpenList);
            if (cur.GetPos().Equals(endNode.GetPos()))
            {
                return GetFinalPath(endNode);
            }
            else
            {
                OpenList.Remove(cur);
                closedList.Add(cur);

                foreach (Node neighbour in GetNeighbours(cur))
                {
                    if (closedList.Contains(neighbour)) continue;

                    int estGCost = cur.gCost + GetCalculatedDistanceCost(cur.GetPos(), neighbour.GetPos());
                    if (estGCost < neighbour.gCost)
                    {
                        neighbour.pastNode = cur;
                        neighbour.gCost = estGCost;
                        neighbour.hCost = GetCalculatedDistanceCost(cur.GetPos(), neighbour.GetPos());
                        neighbour.CalculateFCost();

                        if (!OpenList.Contains(neighbour))
                        {
                            OpenList.Add(neighbour);
                        }
                    }
                }
            }
        }
        return null;
    }

    private List<Node> GetNeighbours(Node cur)
    {
        List<Node> neighbours = new List<Node>();
        Vector2Int curPos = cur.GetPos();
        //Left
        if (roomLayout.GetNode(new Vector2Int(curPos.x - 1, curPos.y)) is Node nodeL)
        {
            neighbours.Add(nodeL);
        }
        //Left Up
        if (roomLayout.GetNode(new Vector2Int(curPos.x - 1, curPos.y + 1)) is Node nodeLU)
        {
            neighbours.Add(nodeLU);
        }
        //Left Down
        if (roomLayout.GetNode(new Vector2Int(curPos.x - 1, curPos.y - 1)) is Node nodeLD)
        {
            neighbours.Add(nodeLD);
        }

        //Right
        if (roomLayout.GetNode(new Vector2Int(curPos.x - 1, curPos.y)) is Node nodeR)
        {
            neighbours.Add(nodeR);
        }
        //Right Up
        if (roomLayout.GetNode(new Vector2Int(curPos.x - 1, curPos.y + 1)) is Node nodeRU)
        {
            neighbours.Add(nodeRU);
        }
        //Right Down
        if (roomLayout.GetNode(new Vector2Int(curPos.x - 1, curPos.y - 1)) is Node nodeRD)
        {
            neighbours.Add(nodeRD);
        }

        //Up
        if (roomLayout.GetNode(new Vector2Int(curPos.x - 1, curPos.y + 1)) is Node nodeU)
        {
            neighbours.Add(nodeU);
        }
        //Down
        if (roomLayout.GetNode(new Vector2Int(curPos.x - 1, curPos.y - 1)) is Node nodeD)
        {
            neighbours.Add(nodeD);
        }

        return neighbours;
    }

    private int GetCalculatedDistanceCost(Vector2Int cur, Vector2Int target)
    {
        int xDistance = Mathf.Abs(cur.x - target.x);
        int yDistance = Mathf.Abs(cur.y - target.y);
        int leftover = Mathf.Abs(xDistance - yDistance);

        return DIAGONAL_MOVE_COST * Mathf.Min(xDistance, yDistance) + STRAIGHT_MOVE_COST * leftover;
    }

    private Node GetLowestFCost(List<Node> pathList)
    {
        Node lowestCost = pathList[0];
        for (int i = 1; i < pathList.Count; i++)
        {
            if (lowestCost.fCost > pathList[i].fCost)
                lowestCost = pathList[i];
        }
        return lowestCost;
    }

    private List<Node> GetFinalPath(Node end)
    {
        List<Node> path = new List<Node>();
        path.Add(end);
        Node cur = end;
        while (cur.pastNode != null)
        {
            path.Add(cur.pastNode);
            cur = cur.pastNode;
        }
        path.Reverse();
        return path;
    }

    public void OnEnter()
    {
        //Debug.Log(roomLayout);
        Debug.Log(roomLayout.GetNodes().Count);
        Color color = new Color(0, 1, 0);
        //foreach (Node node in FindPath()) actualPath.Push(node);
        //targetNode = actualPath.Pop();
        //actualPath = FindPath();
    }

    public void OnExit()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        roadPassed = 0;
    }
}
