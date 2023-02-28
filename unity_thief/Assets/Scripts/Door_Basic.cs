using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Basic : MonoBehaviour{

        public string NextLevel = "MainMenu";
        public GameObject msg1PressE;
        public GameObject msg2NeedKey;
        public bool canPressE =false;

        public GameObject doorOpen;
        public GameObject doorClosed;

        public GameHandler gameHandler;

       void Start(){
              msg1PressE.SetActive(false);
              msg2NeedKey.SetActive(false);
              doorClosed.SetActive(true);
              doorOpen.SetActive(false);

              if (GameObject.FindWithTag("GameHandler") != null){
                gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
              } 
        }

       void Update(){

            if (gameHandler.hasGoldKey){
                doorClosed.SetActive(false);
                doorOpen.SetActive(true);
            }

              if ((canPressE == true) && (Input.GetKeyDown(KeyCode.E))){
                     EnterDoor();
              }
        }

        void OnTriggerEnter2D(Collider2D other){
              if ((other.gameObject.tag == "Player")&&(gameHandler.hasGoldKey)){ ;
                     msg1PressE.SetActive(true);
                     canPressE =true;
              } else if ((other.gameObject.tag == "Player")&&(!gameHandler.hasGoldKey)){
                    msg2NeedKey.SetActive(true);
                     canPressE =false;
              }
        }

        void OnTriggerExit2D(Collider2D other){
              if (other.gameObject.tag == "Player"){
                     msg1PressE.SetActive(false);
                    msg2NeedKey.SetActive(false);
                     canPressE = false;
              }
        }

      public void EnterDoor(){
            SceneManager.LoadScene (NextLevel);
      }

}