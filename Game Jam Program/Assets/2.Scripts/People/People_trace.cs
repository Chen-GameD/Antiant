using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class People_trace : MonoBehaviour
{
    public Vector3Int currentPos;//人物当前位置
    public Vector3Int peopleStart;//起点
    public Vector3Int tracePoint;//终点
    public Tile pathTile;//绿色tile
    public List<Delivery> delivery;
    public Tilemap tilemap;
    public Vector2Int mapSize;//地图尺寸

    public Dictionary<Vector3Int, int> search = new Dictionary<Vector3Int, int>();//要进行的查找任务
    public Dictionary<Vector3Int, int> cost = new Dictionary<Vector3Int, int>();//起点到当前点的消耗
    public Dictionary<Vector3Int, Vector3Int> pathSave = new Dictionary<Vector3Int, Vector3Int>();//保存回溯路径
    public List<Vector3Int> hadSearch = new List<Vector3Int>();//已经查找过的坐标

    public List<Vector3Int> obstacle = new List<Vector3Int>();//障碍物坐标

    private void Start()
    {
        currentPos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(GetComponent<Transform>().position));
        peopleStart = currentPos;
    }

    private void Update()
    {
        if (delivery != null)
        {
            //tracePoint = GetNearestDel(delivery, peopleStart);
        }
        pathSave = AStarSearchPath(tracePoint, peopleStart);
        ShowPath();
    }

    //拿取最近的快递的位置
    //public Vector3Int GetNearestDel(List<Delivery> del, Vector3Int start)
    //{
    //    Vector3Int nearestDel = del[0].pos;
    //    int delCount = 0;
    //    int delNextCount = 0;
    //    foreach (Delivery d in del)
    //    {
    //        delNextCount = GetDelCount(d, start);
    //        if (delCount == 0)
    //            delCount = GetDelCount(d, start);
    //        if (delNextCount < delCount)
    //        {
    //            delCount = delNextCount;
    //            nearestDel = d.pos;
    //        }
    //    }
    //    return nearestDel;
    //}

    ////计算当前快递距离人有多远
    //public int GetDelCount(Delivery del, Vector3Int start)
    //{
    //    pathSave = AStarSearchPath(del.pos, start);
    //    int count = 0;
    //    if (pathSave != null)
    //        count = pathSave.Count;
    //    return count;
    //}
   
    public Dictionary<Vector3Int, Vector3Int> AStarSearchPath(Vector3Int endPos, Vector3Int start)
    {
        //初始化
        search.Clear();
        cost.Clear();
        hadSearch.Clear(); ;
        pathSave.Clear();
        search.Add(start, GetHeuristic(start, endPos));
        cost.Add(start, 0);
        hadSearch.Add(start);
        pathSave.Add(start, start);

        while (search.Count > 0)
        {
            Vector3Int current = GetShortestPos();//获取任务列表里的最少消耗的那个坐标

            if (current.Equals(endPos))
                break;

            List<Vector3Int> neighbors = GetNeighbors(current);//获取当前坐标的邻居

            foreach (var next in neighbors)
            {
                if (!hadSearch.Contains(next))
                {
                    cost.Add(next, cost[current] + 1);//计算当前格子的消耗，其实就是上一个格子加1步
                    search.Add(next, cost[next] + GetHeuristic(next, endPos));//添加要查找的任务，消耗值为当前消耗加上当前点到终点的距离
                    pathSave.Add(next, current);//保存路径
                    hadSearch.Add(next);//添加该点为已经查询过
                }
            }
        }

        if (pathSave.ContainsKey(endPos))
            return pathSave;
        else
            return null;
    }
    //获取周围可用的邻居
    private List<Vector3Int> GetNeighbors(Vector3Int target)
    {
        List<Vector3Int> neighbors = new List<Vector3Int>();

        Vector3Int up = target + Vector3Int.up;
        Vector3Int right = target + Vector3Int.right;
        Vector3Int left = target - Vector3Int.right;
        Vector3Int down = target - Vector3Int.up;

        //Up
        if (up.y < mapSize.y && !obstacle.Contains(up))
        {
            neighbors.Add(up);
        }
        //Right
        if (right.x < mapSize.x && !obstacle.Contains(right))
        {
            neighbors.Add(target + Vector3Int.right);
        }
        //Left
        if (left.x >= 0 && !obstacle.Contains(left))
        {
            neighbors.Add(target - Vector3Int.right);
        }
        //Down
        if (down.y >= 0 && !obstacle.Contains(down))
        {
            neighbors.Add(target - Vector3Int.up);
        }

        return neighbors;
    }
    //获取当前位置到终点的消耗
    private int GetHeuristic(Vector3Int posA, Vector3Int posB)
    {
        return Mathf.Abs(posA.x - posB.x) + Mathf.Abs(posA.y - posB.y);
    }
    //获取任务字典里面最少消耗的坐标
    private Vector3Int GetShortestPos()
    {
        KeyValuePair<Vector3Int, int> shortest = new KeyValuePair<Vector3Int, int>(Vector3Int.zero, int.MaxValue);

        foreach (var item in search)
        {
            if (item.Value < shortest.Value)
            {
                shortest = item;
            }
        }

        search.Remove(shortest.Key);

        return shortest.Key;
    }

    private void ShowPath()
    {
        print(pathSave.Count);
        Vector3Int current = tracePoint;
        float time = 0;

        while (current != peopleStart)
        {
            Vector3Int next = pathSave[current];

            time += Time.deltaTime;
            Debug.Log(time);
            if (time >= 2)
            {
                tilemap.SetTile(current, pathTile);
                current = next;
                time = 0;
            }

            //    time = 0;

            //if (time == 2)
            //{

            //}
        }
    }
}
