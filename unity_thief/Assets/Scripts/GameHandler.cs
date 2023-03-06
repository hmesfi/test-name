using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    private GameObject player;
    private GameObject enemy;
    public static int playerSus = 0;
    private int StartPlayerSus = 0;
    public int limitSus = 5;
    public GameObject susText;

    //public static int gotTokens = 0;
    //public GameObject tokensText;

    //public bool isDefending = false;

    private string thisLevel;
    public bool hasGoldKey = false;
    public bool hasSafeKey = false;
    public GameObject key1icon;
    public GameObject key2icon;
    public GameObject key3icon;
    public GameObject key4icon;

    void Start(){
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

        playerSus = StartPlayerSus;
        updateStatsDisplay();

        key1icon.SetActive(false);
        key2icon.SetActive(false);
        key3icon.SetActive(false);
        key4icon.SetActive(false);

        thisLevel = SceneManager.GetActiveScene().name;
        DisplayKeys(false);
    }

    // public void playerGetTokens(int newTokens)
    // {
    //     gotTokens += newTokens;
    //     updateStatsDisplay();
    // }

    public void DisplayKeys(bool gotKey){
        if (thisLevel == "Scene1"){
            if (gotKey){key1icon.SetActive(true);}
        }
        
        if (thisLevel == "Scene2"){
            key1icon.SetActive(true);
            if (gotKey){key2icon.SetActive(true);}
            }
        if (thisLevel == "Scene3"){
            key1icon.SetActive(true);
            key2icon.SetActive(true);
            if (gotKey){key3icon.SetActive(true);}
            }
        if (thisLevel == "Scene4"){
            key1icon.SetActive(true);
            key2icon.SetActive(true);
            key3icon.SetActive(true);
            if (gotKey){key4icon.SetActive(true);}
        }
    }

    public void SusChange(int sus){
        //if (player.GetComponentInParent<Player_Sus_Meter>().printSus() >= 5f) {
        playerSus += sus;
        Debug.Log("player sus level: " + playerSus);
        updateStatsDisplay();

        if (playerSus >= limitSus){
            playerDies();
        }
    }

    public void updateStatsDisplay(){
        Text SusTextTemp = susText.GetComponent<Text>();
        SusTextTemp.text = "SUS LEVEL: " + playerSus;

        //Text tokensTextTemp = tokensText.GetComponent<Text>();
        //tokensTextTemp.text = "GOLD: " + gotTokens;
    }

    public void playerDies()
    {
        //player.GetComponent<PlayerHurt>().playerDead();  //play Death animation
        StartCoroutine(DeathPause());
    }

    IEnumerator DeathPause()
    {
        //player.GetComponent<PlayerMove>().isAlive = false;
        //player.GetComponent<PlayerJump>().isAlive = false;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("EndLose");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        playerSus = StartPlayerSus;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
