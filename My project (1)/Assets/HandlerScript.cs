using UnityEngine;

public class HandlerScript : MonoBehaviour
{
    private GameObject[,] map = new GameObject[16, 8];
    private GameObject[,] entityMap = new GameObject[16, 8];
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
    public GameObject pawn;

    public GameObject blackTile;
    public GameObject whiteTile;
    public GameObject mud;


    private int n = 0;

    void Start()
    {
        createLevel1();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < pawnHandler.transform.childCount; i++)
            {
                pawnHandler.transform.GetChild(i).GetComponent<Animator>().Play("pawn_activation");
                Debug.Log("asdkjfhl");
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            n++;
            GameObject newPawn = Instantiate(pawn); 
            newPawn.transform.position += Vector3.right * n;
            newPawn.transform.parent = pawnHandler.transform;
        }
    }

    void addGO(GameObject go, int x, int y)
    {   


    }

    void createLevel1()
    {
        GameObject tile;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (i + j % 2 == 0)
                {
                    map[i, j] = Instantiate(blackTile);
                } else
                {
                    map[i, j] = Instantiate(whiteTile);

                }
                map[i, j].transform.position += Vector3.right * i + Vector3.down * j;
            }
        }
        
    }
}
