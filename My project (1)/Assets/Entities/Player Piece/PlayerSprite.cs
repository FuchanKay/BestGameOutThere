using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] PlayerObj playerObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(playerObj.x, y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, y, 0);

    }
}
