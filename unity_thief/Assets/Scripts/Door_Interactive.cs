using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Interactive : MonoBehaviour{

        public string NextLevel = "MainMenu";
        public GameObject msg1PressE;
        public GameObject msg2NeedKey;
        public bool canPressE =false;

        public GameObject doorOpen;
        public GameObject doorClosed;

        public GameHandler gameHandler;
        private string CurrLevel;

       void Start(){
            msg1PressE.SetActive(false);
            msg2NeedKey.SetActive(false);
            doorClosed.SetActive(true);
            doorOpen.SetActive(false);
            CurrLevel = SceneManager.GetActiveScene().name;
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
                  Debug.Log("Let me in!!!");
                  Debug.Log(CurrLevel + "is the CurrLevel");
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
            if (CurrLevel == "Scene1"){
                  Debug.Log("take me to scene 2!!!");
                  SceneManager.LoadScene("Scene2");
            } 
            if (CurrLevel == "Scene2"){
                  SceneManager.LoadScene("Scene3");
            }
            if (CurrLevel == "Scene3"){
                  SceneManager.LoadScene("Scene4");
            }
            if (CurrLevel == "Scene4"){
                  SceneManager.LoadScene("EndWin");
            }
      }

}