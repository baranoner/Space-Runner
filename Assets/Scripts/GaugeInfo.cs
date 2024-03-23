using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GaugeInfo : MonoBehaviour
{
    Tilemap ground;
    GameObject player;

    Slider gaugeInfo;
    float maxDistance;
  


   private void Awake() {
    player = GameObject.FindGameObjectWithTag("Player");
    ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Tilemap>();
    gaugeInfo = GetComponent<Slider>();

    ground.CompressBounds();

    maxDistance = ground.size.x;
    

     gaugeInfo.value = player.transform.position.x / maxDistance;
   }
    private void Update() {
        EveningSpeeds();
    }

    void EveningSpeeds(){
        
        if(gaugeInfo.value < 1){
        gaugeInfo.value = Math.Abs(player.transform.position.x) / maxDistance;
        }
       

    }
}
