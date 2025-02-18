using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int x;
    public int y;
    public int movingX;
    public int movingY;
    [SerializeField] private PlayerSprite playerSprite;
    [SerializeField] private Transform transform;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
