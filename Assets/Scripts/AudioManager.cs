using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip jumpClip;
    [SerializeField] AudioClip pickGemClip;
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
    public void PlayJumpSound(){
        AudioSource.PlayClipAtPoint(jumpClip, Camera.main.transform.position);
    }
    public void PlayPickSound(){
        AudioSource.PlayClipAtPoint(pickGemClip, Camera.main.transform.position);
    }
    

    
}
