using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{

    public GameObject cobblestoneWall;
    public GameObject cobblestone;
    public GameObject player;
    public GameObject slime;
    public GameObject icebubble;
    public GameObject desertbubble;
    public GameObject firebubble;
    public GameObject desertgun;
    public GameObject forestgun;
    public GameObject tundragun;
    public GameObject volcanogun;
    public GameObject boss;
    public GameObject grass;
    public GameObject mud;
    public GameObject sand;
    public GameObject ice;
    public GameObject snow;

    private GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        string map =
            @"
_______________
________S______
___________|___
^^____*____|___
^^_________|_I_
vv______||||||_
.._________|___
//______S__|_D_
--_________|___
_d__l________F_
_______________
_f__t_____!____
";
        var gameArray = map.Split(Environment.NewLine);
        var game2DArray = new char[gameArray.Length - 2, gameArray[1].Length];
        for (int i = 1; i < gameArray.Length - 1; i++)
        {
            char[] text = gameArray[i].ToCharArray();
            for (int j = 0; j < gameArray[i].Length; j++)
            {
                game2DArray[i - 1, j] = text[j];
            }
        }
        
        for (int i = 0; i < game2DArray.GetLength(0); i++) {
            for (int j = 0; j < game2DArray.GetLength(1); j++)
            {
                switch(game2DArray[i, j])
                {
                    case '|':
                        tile = cobblestoneWall;
                        break;
                    case '*':
                        tile = player;
                        break;
                    case 'S':
                        tile = slime;
                        break;
                    case 'I':
                        tile = icebubble;
                        break;
                    case 'D':
                        tile = desertbubble;
                        break;
                    case 'F':
                        tile = firebubble;
                        break;
                    case 'd':
                        tile = desertgun;
                        break;
                    case 'f':
                        tile = forestgun;
                        break;
                    case 't':
                        tile = tundragun;
                        break;
                    case 'l':
                        tile = volcanogun;
                        break;
                    case '!':
                        tile = boss;
                        break;
                    case '^':
                        tile = grass;
                        break;
                    case 'v':
                        tile = mud;
                        break;
                    case '.':
                        tile = sand;
                        break;
                    case '/':
                        tile = ice;
                        break;
                    case '-':
                        tile = snow;
                        break;
                    case '_':
                    default:
                        tile = cobblestone;
                        break;
                }
                Instantiate(tile, new Vector3(j+0.5f, 11.5f-i, 0f), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
