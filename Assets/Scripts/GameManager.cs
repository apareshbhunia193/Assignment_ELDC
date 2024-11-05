using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerMaxHealth = 100;
    [SerializeField]int playerCurrentHealth;
    [SerializeField] int playerScore;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerCurrentHealth = playerMaxHealth;
        healthSlider.maxValue = playerMaxHealth;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTheScore(int val){
        playerScore += val;
        scoreText.text = "Score: " + playerScore;
        if(playerScore >= 170){
            SceneLoader.instance.SetThePlayerScore(playerScore);
            SceneLoader.instance.LoadTheGameOverScene();
        }
    }

    public void UpdateTheHealthStatus(){
        playerCurrentHealth -= 10;
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth, 0, playerMaxHealth);
        healthSlider.value = playerCurrentHealth;
        if(playerCurrentHealth == 0){
            SceneLoader.instance.SetThePlayerScore(playerScore);
            SceneLoader.instance.LoadTheGameOverScene();
        }
    }
}
