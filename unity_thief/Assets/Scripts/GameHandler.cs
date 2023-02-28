using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      private GameObject player;
      public static int playerSus = 0;
      public int StartPlayerSus = 0;
      public GameObject susText;

      public static int gotTokens = 0;
      //public GameObject tokensText;

      public bool isDefending = false;

      //public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

      private string sceneName;

      public bool hasGoldKey = true;

      void Start(){
            player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerSus = StartPlayerSus;
            //}
            updateStatsDisplay();
      }

      public void playerGetTokens(int newTokens){
            gotTokens += newTokens;
            updateStatsDisplay();
      }

      public void playerGetFound(int damage){
           if (isDefending == false){
                  playerSus -= damage;
                  if (playerSus >=0){
                        updateStatsDisplay();
                  }
                  if (damage > 0){
                       player.GetComponent<PlayerFound>().playerHit();       //play Found animation
            }
            }

           if (playerSus < StartPlayerSus){
                  playerHealth = StartPlayerHealth;
                  updateStatsDisplay();
            }

           if (playerHealth >= 5){
                  playerHealth = 0;
                  updateStatsDisplay();
                  playerDies();
            }
      }

      public void updateStatsDisplay(){
        Text healthTextTemp = susText.GetComponent<Text>();
        healthTextTemp.text = "SUS LEVEL: " + playerHealth;

        Text tokensTextTemp = tokensText.GetComponent<Text>();
        tokensTextTemp.text = "GOLD: " + gotTokens;
    }

      public void playerDies(){
            //player.GetComponent<PlayerHurt>().playerDead();       //play Death animation
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            //player.GetComponent<PlayerMove>().isAlive = false;
            //player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
      }

      public void StartGame() {
            SceneManager.LoadScene("Level1");
      }

      public void RestartGame() {
            SceneManager.LoadScene("MainMenu");
            playerHealth = StartPlayerHealth;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
}
