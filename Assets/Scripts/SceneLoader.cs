using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    private int playerScore;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else if(instance != this){
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetThePlayerScore(int val){
        playerScore = val;
    }

    public void LoadTheGameOverScene(){
        SceneManager.LoadScene("GameOver");
    }
    public void LoadTheMainMenuScene(){
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadTheGameScene(){
        SceneManager.LoadScene("Level 1");
    }

    public int GetThePlayerScore(){
        return playerScore;
    }
}
