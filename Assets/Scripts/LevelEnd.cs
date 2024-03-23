using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
   GameObject player;
   GameObject diggingMachine;
   GameObject healthManager;
   [SerializeField] GameObject gameFinishPanel;

   private void Awake() {
    player = GameObject.FindGameObjectWithTag("Player");
    healthManager = GameObject.FindGameObjectWithTag("HealthManager");
    diggingMachine = GameObject.FindGameObjectWithTag("Digging Machine");
   }

   private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Player"){
        player.GetComponent<Player>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        player.GetComponent<Animator>().SetFloat("xVelocity", 0);
        diggingMachine.GetComponent<DiggingMachine>().enabled = false;
        diggingMachine.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        StartCoroutine(WaitandNext());
        
    }
     IEnumerator WaitandNext(){
        yield return new WaitForSeconds(1);
        if(SceneManager.GetActiveScene().buildIndex == 2){
            gameFinishPanel.SetActive(true);
        }
        else{
            Destroy(healthManager);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
   }
}
