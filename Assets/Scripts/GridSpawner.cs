using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{

    public GameObject floor_tile;
    public GameObject player;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        string[] gameArray = new string[] {
            "000000000000000",
            "000000000000000",
            "000000000001000",
            "000P00000001000",
            "000000000001000",
            "000000001111110",
            "000000000001000",
            "000000000001000",
            "000000000001000",
            "000000000000000",
            "000000000000000",
            "000000000000000",
        };
        char[,] game2DArray = new char[gameArray.Length,gameArray[0].Length];
        for (int i = 0; i < gameArray.Length; i++) {
            char[] text = gameArray[i].ToCharArray();
            for (int j = 0; j < gameArray[i].Length; j++) {
                game2DArray[i,j] = text[j];
            }
        }
        for (int i = 0; i < game2DArray.GetLength(0); i++) {
            for (int j = 0; j < game2DArray.GetLength(1); j++) {
                if (game2DArray[i, j] == '1') {
                    Instantiate(floor_tile, new Vector3(j+0.5f, 11.5f-i, 0f), Quaternion.identity);
                } 
                if (game2DArray[i, j] == 'P') {
                    Instantiate(player, new Vector3(j+0.5f, 11.5f-i, 0f), Quaternion.identity);
                } 
                if (game2DArray[i, j] == 'E') {
                    Instantiate(enemy, new Vector3(j+0.5f, 11.5f-i, 0f), Quaternion.identity);
                } 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
