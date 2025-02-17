using UnityEngine;

public class HandlerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public const int moveDistance = 1;
    private float location = 2;
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            pawnHandler.transform.GetChild(0).GetComponent<Animator>().Play("pawn_activation");
            Debug.Log("asdkjfhl");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            

        }
    }
}
