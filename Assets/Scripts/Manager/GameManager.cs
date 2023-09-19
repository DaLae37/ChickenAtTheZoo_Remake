using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GetGameManager()
    {
        if(instance == null)
        {
            GameObject gameManager = new GameObject();
            gameManager.name = "GameManager";
            gameManager.AddComponent<GameManager>();
            DontDestroyOnLoad(gameManager);
            instance = gameManager.GetComponent<GameManager>();
        }
        return instance;
    }
    private static GameManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void CheckResolution()
    {
        Debug.Log("ю╦гого");
        int newHeight = Screen.height * 16 / 9;
        if(Screen.currentResolution.height != newHeight)
        {
            Screen.SetResolution(Screen.width, newHeight, true);
        }
    }
}
