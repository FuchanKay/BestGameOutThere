using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Onclick : MonoBehaviour
{
    public Button yourButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        SceneManager.CreateScene(sceneName: "Level1");
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(sceneName: "Level1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
