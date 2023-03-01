using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Basic : MonoBehaviour{

        public string NextLevel = "MainMenu";

        void OnTriggerEnter2D(Collider2D other){
              if (other.gameObject.tag == "Player"){ ;
                  SceneManager.LoadScene (NextLevel);
              }
        }

}