using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPit : MonoBehaviour
{
    Player player;
    private void Awake() {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        player.Die();
    }
}
