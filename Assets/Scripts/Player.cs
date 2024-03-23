using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    BoxCollider2D myBoxCollider;
    CinemachineVirtualCamera cinemachine;
    DiggingMachine diggingMachineScript;
    Health healthScript;
    bool isGrounded = false;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeedy = 5f;
    [SerializeField] float jumpSpeedx = 5f;
    [SerializeField] GameObject failPanel;
    TextMeshProUGUI diamondCountText;
    AudioManager audioManager;
    [HideInInspector]public int diamondCount = 0;
    private void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        cinemachine = FindObjectOfType<CinemachineVirtualCamera>();
        diggingMachineScript = FindObjectOfType<DiggingMachine>();
        healthScript = FindObjectOfType<Health>();
        diamondCountText = GameObject.FindGameObjectWithTag("Gem Info").GetComponent<TextMeshProUGUI>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnJump(InputValue value){
        if(value.isPressed && isGrounded){
            myRigidbody.velocity += new Vector2 (jumpSpeedx, jumpSpeedy);
            isGrounded = false;
            myAnimator.SetBool("isJumping", !isGrounded);
            audioManager.PlayJumpSound();
        }
        
    }
  
    void Update()
    {
        Move();
        UIUpdate();
        
    }

    void Move(){
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        myAnimator.SetFloat("xVelocity", Math.Abs(myRigidbody.velocity.x));
        myAnimator.SetFloat("yVelocity", myRigidbody.velocity.y);
    }



    public void Die(){
        moveSpeed = 0f;
        myRigidbody.velocity += new Vector2(0f, 7f);
        myAnimator.SetBool("isDead", true);
        myBoxCollider.enabled = false;
        cinemachine.Follow = null;
        diggingMachineScript.enabled = false;
        healthScript.DecreaseHealth();

        
        StartCoroutine(WaitandLoad(2));
       

    }
    void UIUpdate(){
        diamondCountText.text = diamondCount.ToString();
    }
    IEnumerator SpeedDecrease(int second, float amount){
        moveSpeed -= amount;
        yield return new WaitForSeconds(second);
        moveSpeed += amount;
    }
     IEnumerator SpeedIncrease(int second, float amount){
        moveSpeed += amount;
        yield return new WaitForSeconds(second);
        moveSpeed -= amount;
    }
    IEnumerator WaitandLoad(int second){
        yield return new WaitForSeconds(second);
         if(healthScript.GetHealth() != 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if(healthScript.GetHealth() == 0){
            failPanel.SetActive(true);
        }
       
    }
   


    private void OnTriggerEnter2D(Collider2D other) {
        isGrounded = true;
        myAnimator.SetBool("isJumping", !isGrounded);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Digging Machine"){
            Die();
        }
        else if(other.gameObject.tag == "Diamond"){
            diamondCount++;
            Destroy(other.gameObject);
            audioManager.PlayPickSound();
        }
        else if(other.gameObject.tag == "Shards"){
            StartCoroutine(SpeedDecrease(1, 1f));
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Energy Pack"){
            StartCoroutine(SpeedIncrease(1,1f));
            Destroy(other.gameObject);
        }
    }

    
    
    
    
}
