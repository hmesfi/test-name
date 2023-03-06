using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeInteraction : MonoBehaviour
{
    private GameHandler gameHandler;
    public GameObject safeArt;


    void Start(){
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    void Update(){
        if (gameHandler.hasSafeKey == true) {
            // anim.SetBool("Glow", true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && gameHandler.hasSafeKey == true ){
            // open safe UI where player has to drag money off the screen
        }
    }

  
}
