using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] int health = 3;
   TextMeshProUGUI healthInfo;
  private void Awake() {
    ManageSingleton();
    
  }
  private void Start() {
    healthInfo = GameObject.FindGameObjectWithTag("Health Info").GetComponent<TextMeshProUGUI>();
  }
    void Update()
    {
        UpdateUI();
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
    public void DecreaseHealth(){
        health = health -1;
    }
    public int GetHealth(){
        return health;
    }
    void UpdateUI(){
        healthInfo.text = health.ToString();
    }
}
