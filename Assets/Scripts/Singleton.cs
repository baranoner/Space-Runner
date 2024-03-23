using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
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
}
