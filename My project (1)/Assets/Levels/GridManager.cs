using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;
using System.Collections.Generic;
using System.Collections;

public class GridManager : MonoBehaviour
{
    //map settings
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;

    //camera
    [SerializeField] private Transform _cam;

    //entity handlers
    [SerializeField] private PlayerObj _playerObj;
    [SerializeField] private PawnHandler _pawnHandler;

    private Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();

    private void Start()
    {
        GenerateGrid();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            UpdateTiles12();
        }
    }
    private void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);

                spawnedTile.name = $"Tile {x} {y}";

                var isOffSet = (x + y) % 2 == 0;
                spawnedTile.Init(isOffSet);

                _tiles.Add(new Vector2(x, y), spawnedTile);
            }
        }
        _tiles.TryGetValue(new Vector2(_playerObj.x, _playerObj.y), out Tile tile);
        _playerObj.transform.parent = tile.transform;


        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
    private void UpdateTiles12()
    {
        _tiles.TryGetValue(new Vector2(_playerObj.x, _playerObj.y), out Tile tile);
        _playerObj.transform.parent = tile.transform;
        _playerObj.y++;
    }
}
