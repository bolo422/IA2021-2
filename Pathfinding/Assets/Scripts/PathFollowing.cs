using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public float velocity;
    Vector3[] waypoints;

    public MazeGenerator mazeObj;

    int mazeWidth, mazeDepth;
    int[,] maze;
    Vector3[] tiles;
    int tilesCont = 0;
    public int wpCont = 0;

    public int current;

    void Start()
    {
        maze = mazeObj.maze;
        mazeWidth = mazeObj.mazeWidth;
        mazeDepth = mazeObj.mazeDepth;
        //tiles = mazeObj.tiles;

        //setWaypoints();
    }

    //void Update()
    //{
    //    if (transform.position.x != waypoints[current].x && transform.position.z != waypoints[current].z)
    //    {
    //        Vector3 pos = Vector3.MoveTowards(transform.position, waypoints[current], velocity * Time.deltaTime);
    //        GetComponent<Rigidbody>().MovePosition(pos);
    //    }
    //    else if (current < waypoints.Length-1) current = current+1;
    //}

    void setWaypoints()
    {
        for (int i = 0; i < mazeDepth; i++) //z
        {
            for (int j = 0; j < mazeWidth; j++) //x
            {
                if(maze[i, j] == 0)
                {
                    waypoints[wpCont] = tiles[tilesCont];
                    wpCont = wpCont + 1;
                }
                tilesCont = tilesCont + 1;

            }
        }
    }
}
