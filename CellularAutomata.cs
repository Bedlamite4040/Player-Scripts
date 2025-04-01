using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellularAutomata : MonoBehaviour
{
    
    public int repetitions = 3;
    public int width = 20;
    public int height = 20;
    public int[,] grid;
    public int[,] newgrid;
    
    // Start is called before the first frame update
    void Start()
    {
        int[,] grid = new int[width, height];
        int[,] newgrid = new int[width, height];

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                grid[x, y] = Random.Range(0, 2);
                Debug.Log(grid[x, y]);
            }
        }
        
        for(int i = 0; i < repetitions; i++){
            for(int x = 0; x < width; x++){
                for(int y = 0; y < height; y++){
                    int[] cellcount = CheckCells(grid, x, y);
                    Debug.Log(cellcount[0]);
                    Debug.Log(cellcount[1]);

                    if(cellcount[0] > 4){
                        newgrid[x,y] = 1;
                    }
                    else{
                        newgrid[x,y] = 0;
                    }
                }
            }

            for(int x = 0; x < width; x++){
                for(int y = 0; y < height; y++){
                    grid[x,y] = newgrid[x,y];
                }
            }
        }

        CreateTiles(grid, height, width);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject WallTile;
    public GameObject FloorTile;
    public void CreateTiles(int[,] grid, int height, int width){
        Debug.Log("ye");

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                if(grid[x,y] == 1){
                    Instantiate(WallTile, new Vector3(x * 10, 0, y * 10), Quaternion.identity);
                }
                else{
                    Instantiate(FloorTile, new Vector3(x * 10, 0, y * 10), Quaternion.identity);
                }
            }
        }
    }


    static int[] CheckCells(int[,] grid, int x, int y){
        Debug.Log("ah");
        int wallcount = 0;
        int floorcount = 0;
        try{
            if(grid[x - 1, y - 1] == 0){
                floorcount += 1;
            }
            else{
                wallcount += 1;
            }
        }
        catch{
            Debug.Log("Exception");
            floorcount += 1;
        }
        try{
            if(grid[x - 1, y] == 0){
                floorcount += 1;
            }
            else{
                wallcount += 1;
            }
        }
        catch{
            Debug.Log("Exception");
            floorcount += 1;
        }
        try{
            if(grid[x - 1, y + 1] == 0){
                floorcount += 1;
            }
            else{
                wallcount += 1;
            }
        }
        catch{
            Debug.Log("Exception");
            floorcount += 1;
        }
        try{
            if(grid[x, y + 1] == 0){
                floorcount += 1;
            }
            else{
                wallcount += 1;
            }
        }
        catch{
            Debug.Log("Exception");
            floorcount += 1;
        }
        try{
            if(grid[x + 1, y + 1] == 0){
                floorcount += 1;
            }
            else{
                wallcount += 1;
            }
        }
        catch{
            Debug.Log("Exception");
            floorcount += 1;
        }
        try{
            if(grid[x + 1, y] == 0){
                floorcount += 1;
            }
            else{
                wallcount += 1;
            }
        }
        catch{
            Debug.Log("Exception");
            floorcount += 1;
        }
        try{
            if(grid[x + 1, y - 1] == 0){
                floorcount += 1;
            }
            else{
                wallcount += 1;
            }
        }
        catch{
            Debug.Log("Exception");
            floorcount += 1;
        }
        try{
            if(grid[x, y - 1] == 0){
                floorcount += 1;
            }
            else{
                wallcount += 1;
            }
        }
        catch{
            Debug.Log("Exception");
            floorcount += 1;
        }
        int[] cellcount = new int[2];
        cellcount[0] = floorcount;
        cellcount[1] = wallcount;

        return cellcount;
    }
}
