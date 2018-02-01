using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController main;
    
    public string gameState = "live";
    public int keys = 0;
    public float playbackSpeed = 1f;
    int counter = 0;
    [SerializeField] string[] level = new string[3];
    public float narrativeStage = 0f;
    
    // Use this for initialization
    private void Awake()
    {
        main = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void LateUpdate () {
        
        switch (gameState)
        {
            case "reset":
                counter++;
                if (counter >= 1 )
                {
                    gameState = "live";
                    counter = 0;
                }
                break;

            case "level-complete":
                SceneManager.LoadScene(level[1],LoadSceneMode.Single);
                break;
            
        }
    }
}
