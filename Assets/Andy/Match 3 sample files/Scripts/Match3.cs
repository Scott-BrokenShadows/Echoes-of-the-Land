using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match3 : MonoBehaviour
{
    public ArrayLayout boardLayout;
    int width = 9;
    int height = 14;
    Node[,] board;

    System.Random random;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void StartGame()
    {
        string seed = getRandomSeed();
        random = new System.Random(seed.GetHashCode());

        InitializeBoard();
    }

    void InitializeBoard()
    {
        board = new Node[width, height];
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                board[x,y] = new Node(-1, new Point(x,y));
            }
        }   
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    string getRandomSeed()
    {
        string seed = "";
        string acceptableChara = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcefghijklmnopqrstuvwxyz1234567890!@#$%^&*()";
        for(int i = 0; i < 20; i++)
            seed += acceptableChara[Random.Range(0, acceptableChara.Length)];
        return seed;
    }
}

[System.Serializable]
public class Node
{
    public int value; //0 = blank, 1 = cube, 2 = sphere, 3 = cylinder, 4 = pyramid, 5 = diamond, -1 = hole
    public Point index; 

    public Node(int v, Point i)
    {
        value = v;
        index = i;
    }
}