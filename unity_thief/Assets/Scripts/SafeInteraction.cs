// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SafeKeyInteraction : MonoBehaviour
// {
//     private GameHandler gameHandler;
//     public GameObject safekeyArt;


//     void Start(){
//         if (GameObject.FindWithTag("GameHandler") != null){
//             gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
//         }
//         safekeyArt.SetActive(false);
//     }

//     void Update(){
//         if (gameHandler.hasGoldKey == true) {
//             safekeyArt.SetActive(true);
//         }
//     }

//     public void OnTriggerEnter2D(Collider2D other)
//     {
//         if ((other.gameObject.tag == "Player") && gameHandler.hasGoldKey == true ){
//             safekeyArt.SetActive(false);
//             gameHandler.hasSafeKey = true;
//         }
//     }

  
// }
