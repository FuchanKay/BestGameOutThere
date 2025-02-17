using UnityEngine;

public class HandlerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public const int moveDistance = 1;
    public GameObject player;
    public GameObject rookHandler;
    public GameObject bishopHandler;
    public GameObject pawnHandler;
    public GameObject knightHandler;
    public GameObject queenHandler;
    public GameObject kingHandler;
    public GameObject wallHandler;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
            moveDirection = Vector3.up;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
            moveDirection = Vector3.down;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
            moveDirection = Vector3.left;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
            moveDirection = Vector3.right;
        if (Input.GetKeyDown(KeyCode.Space)) {

        }


        Vector3 newPosition = transform.position + moveDirection * moveDistance;
        player.transform.position = newPosition;
    }
}
