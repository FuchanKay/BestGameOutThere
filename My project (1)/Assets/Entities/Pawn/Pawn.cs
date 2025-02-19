using Unity.Mathematics;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int x;
    public int y;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            this.GetComponent<Animator>().Play("pawn_activation");
        }
    }
}
