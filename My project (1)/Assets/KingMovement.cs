using UnityEngine;

public class KingMovement : MonoBehaviour
{
    public float moveDistance = 1f;

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            moveDirection = Vector3.up;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            moveDirection = Vector3.down;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            moveDirection = Vector3.left;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            moveDirection = Vector3.right;

        if (moveDirection != Vector3.zero)
        {
            Vector3 newPosition = transform.position + moveDirection * moveDistance;

            if (newPosition.x >= -2.5f && newPosition.x <= 2.5f && newPosition.y >= -2.5f && newPosition.y <= 2.5f)
            {
                transform.position = newPosition;
                CheckRookAlignment();
            }
        }
    }

    void CheckRookAlignment()
    {
        GameObject rook = GameObject.FindGameObjectWithTag("rook");
        if (rook != null)
        {
            Vector3 kingPos = transform.position;
            Vector3 rookPos = rook.transform.position;

            if (kingPos.x == rookPos.x || kingPos.y == rookPos.y)
            {
                rook.transform.position = kingPos;
            }
        }
    }
}
