using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggingMachine : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D myRigidBody;
    AudioManager audioManager;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
       FollowPlayer();
    }
    void FollowPlayer(){
    
    myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
    }
}
