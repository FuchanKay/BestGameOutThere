using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite _whiteTile, _blackTile;
    [SerializeField] private SpriteRenderer _renderer;
    
    public void Init(bool isOffSet)
    {
        //int rotation = Random.Range(0, 4);
        _renderer.sprite = _whiteTile;
        _renderer.sprite = isOffSet ? _whiteTile : _blackTile;
        //_renderer.transform.rotation = Quaternion.Euler(0, 0, 90 * rotation);
    }
}
