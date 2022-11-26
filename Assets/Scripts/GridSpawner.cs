using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{

    public GameObject wall;
    public GameObject player;
    public GameObject slime;
    public GameObject icebubble;
    private GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        string[] gameArray = new string[] {
            "000000000000000",
            "00000000S000000",
            "000000000001000",
            "000P00000001000",
            "0000000000010I0",
            "000000001111110",
            "000000000001000",
            "00000000S0010I0",
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
                    tile = wall;
                } 
                if (game2DArray[i, j] == 'P') {
                    tile = player;
                } 
                if (game2DArray[i, j] == 'S') {
                    tile = slime;
                } 
                if (game2DArray[i, j] == 'I') {
                    tile = icebubble;
                } 
                if (game2DArray[i, j] != '0') {
                Instantiate(tile, new Vector3(j+0.5f, 11.5f-i, 0f), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}