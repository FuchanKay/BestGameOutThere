using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using System.Data;

public class GridManager : MonoBehaviour
{
    //map settings
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    private int _playerStartX, _playerStartY;

    //camera
    [SerializeField] private Transform _cam;

    //entity handlers
    [SerializeField] private PlayerObj _playerObj;
    [SerializeField] private Pawn pawn;

    [SerializeField] private GameObject map;
    private Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();

    private bool canInput = true;

    private void Start()
    {
        _playerStartX = _playerObj.x;
        _playerStartY = _playerObj.y;
        GenerateGrid();
        _playerObj.transform.position = getTile(_playerObj.x, _playerObj.y).transform.position;    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canInput)
        {
            UpdateTiles12();
        }
        if (Input.GetKeyDown(KeyCode.D) && canInput)
        {
            UpdateTiles3();
        }
        if (Input.GetKeyDown(KeyCode.S) && canInput)
        {
            UpdateTiles6();
        }
        if (Input.GetKeyDown(KeyCode.A) && canInput)
        {
            UpdateTiles9();
        }
        if (Input.GetKeyDown(KeyCode.Space) && canInput)
        {
            UpdateTiles0();
        }
        bool zerozeroHasKing = getTile(0, 0).transform.Find("King");
    }
    private void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                spawnedTile.transform.parent = map.transform;
                spawnedTile.name = $"Tile {x} {y}";

                var isOffSet = (x + y) % 2 == 0;
                spawnedTile.Init(isOffSet);

                _tiles.Add(new Vector2(x, y), spawnedTile);
            }
        }
        Tile tile = getTile(_playerStartX, _playerStartY);
        _playerObj.transform.parent = tile.transform;

        createPawn(4, 4);
        createPawn(5, 5);

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
    }
    private void UpdateTiles12()
    {
        if (canMove12())
        {
            _tiles.TryGetValue(new Vector2(_playerObj.x, _playerObj.y + 1), out Tile tile);
            _playerObj.transform.parent = tile.transform;
            _playerObj.GetComponent<Animator>().Play("MoveUp");
            _playerObj.transform.position = tile.transform.position;
            _playerObj.y++;
        }
    }


    private void UpdateTiles3()
    {
        if (_playerObj.x + 1 < _width)
        {
            _tiles.TryGetValue(new Vector2(_playerObj.x + 1, _playerObj.y), out Tile tile);
            _playerObj.transform.parent = tile.transform;
            _playerObj.GetComponent<Animator>().Play("MoveRight");
            _playerObj.transform.position = tile.transform.position;
            _playerObj.x++;

        }
    }

    private void UpdateTiles6()
    {
        if (_playerObj.y - 1 >= 0)
        {
            _tiles.TryGetValue(new Vector2(_playerObj.x, _playerObj.y - 1), out Tile tile);
            _playerObj.transform.parent = tile.transform;
            _playerObj.GetComponent<Animator>().Play("MoveDown");
            _playerObj.transform.position = tile.transform.position;
            _playerObj.y--;
        }

    }
    private void UpdateTiles9()
    {
        if (_playerObj.x - 1 >= 0)
        {
            _tiles.TryGetValue(new Vector2(_playerObj.x - 1, _playerObj.y), out Tile tile);
            _playerObj.transform.parent = tile.transform;
            _playerObj.transform.position = tile.transform.position;
            _playerObj.x--;
            _playerObj.GetComponent<Animator>().Play("MoveLeft");
        }
    }
    private void UpdateTiles0()
    {

    }

    private bool canMove12()
    {
        Tile tile = getTile(_playerObj.x, _playerObj.y);
        bool hasEntity = this.hasEntity(tile);
        return _playerObj.y + 1 < _height && !hasEntity;
    }
    private bool canMove3()
    {
        return true;
    }
    private bool canMove6()
    {
        return true;
    }
    private bool canMove9()
    {
        return true;
    }
    private Tile getTile(int x, int y)
    {
        _tiles.TryGetValue(new Vector2(x, y), out Tile tile);
        return tile;
    }

    private void createPawn(int x, int y)
    {
        Pawn newPawn = Instantiate(pawn);
        newPawn.name = "pawn";
        Tile tile = getTile(x, y);
        newPawn.transform.parent = tile.transform;
        newPawn.transform.position = tile.transform.position;
    }
    private bool hasEntity(Tile tile)
    {
        for (int i = 0; i < tile.transform.childCount; i++)
        {
            GameObject child = tile.transform.GetChild(i).gameObject;
            if (isEntity(child))
            {
                return true;
            }
        }
        return false;
    }
    private bool isEntity(GameObject obj)
    {
        Debug.Log(obj.name);
        //TODO: add more entities
        return obj.name == "pawn";
    }

}
