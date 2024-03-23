using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameObject healthManager;
    GameObject singletonCanvas;

    private void Awake() {
        ManageSingleton();
        

    }
     void ManageSingleton(){
    int instanceCount = FindObjectsOfType(GetType()).Length;
    if(instanceCount > 1){
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    else{
        DontDestroyOnLoad(gameObject);
    }
    }
   public void MainMenuButton(){
    healthManager = GameObject.FindGameObjectWithTag("HealthManager");
    singletonCanvas = GameObject.FindGameObjectWithTag("Singleton Canvas");
    Destroy(singletonCanvas);
    Destroy(healthManager);
    SceneManager.LoadScene("Main Menu");
   }
   public void Level1Button(){
    healthManager = GameObject.FindGameObjectWithTag("HealthManager");
    Destroy(healthManager);
    SceneManager.LoadScene("Level 1");
   }
   public void Level2Button(){
    healthManager = GameObject.FindGameObjectWithTag("HealthManager");
    Destroy(healthManager);
    SceneManager.LoadScene("Level 2");
   }
   public void ExitButton(){
    Application.Quit();
   }
}
