using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    void Start() {
        if(scoreText != null){
            scoreText.text = "Your score: " + SceneLoader.instance.GetThePlayerScore();
        }
    }
    public void OnClickPlayButton(){
        SceneLoader.instance.LoadTheGameScene();
    }

    public void OnClickMainMenuButton(){
        SceneLoader.instance.LoadTheMainMenuScene();
    }
}
