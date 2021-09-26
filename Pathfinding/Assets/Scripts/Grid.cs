using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform StartPosition; //Posi��o inicial do pathfinding
    public LayerMask WallMask; //layer mask das paredes
    public Vector2 gridWorldSize; //dimensoes do grid em "metros"
    public float nodeRadius; //raio de cada nodo no grid
    public float Distance; //distancia entre os nodos

    Node[,] grid; //array de nodos
    public List<Node> FinalPath; //caminho final

    float nodeDiameter; //diametro do nodo, dobro do raio colocado no inspector
    int gridSizeX, gridSizeY; //dimens�es do grid em int

    private void Start()
    {
        nodeDiameter = nodeRadius * 2; // calcula o diametro do nodo
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);// dividimos o valor do grid em "metros" pelo tamanho do nodo para obtermos o tamanho do grid em int
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);// dividimos o valor do grid em "metros" pelo tamanho do nodo para obtermos o tamanho do grid em int
        CreateGrid(); //cria��o do grid
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY]; //declara��o do array de nodos
        Vector3 bottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward* gridWorldSize.y / 2; // m�todo para encontrar a posi��o no mundo do canto inferiro esquerdo do grid
        for (int x = 0; x < gridSizeX; x++) //loop do array de nodos
        {
            for (int y = 0; y < gridSizeY; y++) // loop do array de nodos
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool Wall = true; //declaro a vari�vel e j� marco o nodo como parede

                if (Physics.CheckSphere(worldPoint, nodeRadius, WallMask)) // verificamos se o nodo n�o colide com a parede
                {
                    Wall = false; //se n�o colide, n�o � uma parede
                }

                grid[x, y] = new Node(Wall, worldPoint, x, y); // crio um novo nodo no array
            }
        }
    }

    public Node NodeFromWorldPosition(Vector3 a_WorldPosition)
    {
        float xpoint = ((a_WorldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
        float ypoint = ((a_WorldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y);

        xpoint = Mathf.Clamp01(xpoint);
        ypoint = Mathf.Clamp01(ypoint);

        int x = Mathf.RoundToInt((gridSizeX - 1) * xpoint);
        int y = Mathf.RoundToInt((gridSizeY - 1) * ypoint);

        return grid[x, y];
    }

    public List<Node> GetNeighboringNodes(Node a_Node)
    {
        List<Node> NeighboringNodes = new List<Node>();
        int xCheck;
        int yCheck;

        //Right Side
        xCheck = a_Node.gridX + 1;
        yCheck = a_Node.gridY;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Left Side
        xCheck = a_Node.gridX - 1;
        yCheck = a_Node.gridY;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Up Side
        xCheck = a_Node.gridX;
        yCheck = a_Node.gridY + 1;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        //Down Side
        xCheck = a_Node.gridX;
        yCheck = a_Node.gridY - 1;
        if (xCheck >= 0 && xCheck < gridSizeX)
        {
            if (yCheck >= 0 && yCheck < gridSizeY)
            {
                NeighboringNodes.Add(grid[xCheck, yCheck]);
            }
        }

        return NeighboringNodes;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

        if (grid != null)
        {
            foreach(Node node in grid)
            {
                if (node.IsWall)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.yellow;
                }

                if(FinalPath != null)
                {
                    if (FinalPath.Contains(node))
                    {
                        //Debug.Log("Caminho encontrado");
                        Gizmos.color = Color.red;

                    }
                }

                Gizmos.DrawCube(node.Position, Vector3.one * (nodeDiameter - Distance));
            }
                
        }
    }


}
