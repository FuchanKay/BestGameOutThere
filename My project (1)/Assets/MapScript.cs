using Unity.VisualScripting;
using UnityEngine;

public class Tile
{
    private bool isPlayer = false;
    private void setPlayer(bool isPlayer)
    {
        this.isPlayer = isPlayer;
    }
    private bool isBrickTile = true;
}

public class MapScript : MonoBehaviour
{
    private int mapHeight = 15;
    private int mapWidth = 15;
    Tile[,] map;
    void Start()
    {
        map = new Tile[mapWidth, mapHeight];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
