using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private const float TILESIZE = (float)0.036;
    private const float DELTAGRID = (float)0.126;
    private Tile[,] _grid = new Tile[8, 8];

    [SerializeField] 
    private float _width, _height;

    [SerializeField] 
    private Tile _tilePrefab;

    [SerializeField]
    private Checker _blackChecker;  
    
    [SerializeField]
    private Checker _whiteChecker;

    void Start()
    {
        GenerateGrid();
        SpawnCheckers();
    }

    private void SpawnCheckers()
    {
        Vector3 rotation = new Vector3(-90, 0, 0);

        //white
        for (int i = 0; i <= 2; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 != 0)
                {
                    Vector3 tileCenter = _grid[i, j].CenterLocation();
                    tileCenter.y += (float)0.00101;
                    var spawnedChecker = Instantiate(_whiteChecker, tileCenter, Quaternion.Euler(rotation));
                }
            }
        }        
        
        //black
        for (int i = 5; i <= 7; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 != 0)
                {
                    Vector3 tileCenter = _grid[i, j].CenterLocation();
                    tileCenter.y += (float)0.00101;
                    var spawnedChecker = Instantiate(_blackChecker, tileCenter, Quaternion.Euler(rotation));
                }
            }
        }
    }

    private void GenerateGrid()
    {
        for (double x = 0; x < _width; x += TILESIZE)
        {
            int numX = (int)(x / TILESIZE);
            for (double y = 0; y < _height; y += TILESIZE)
            {
                int numY = (int)(y / TILESIZE);
                var spawnedTile = Instantiate(_tilePrefab, new Vector3((float)(x - DELTAGRID), (float)0.0101, (float)(y - DELTAGRID)), Quaternion.identity);
                spawnedTile.name = $"Tile {numX} {numY}";
                spawnedTile.gameObject.SetActive(false);
                _grid[numX, numY] = spawnedTile;
            }
        }
    }
}
