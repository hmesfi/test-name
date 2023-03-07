using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeKeyInteraction : MonoBehaviour
{
    private GameHandler gameHandler;
    public GameObject safekeyArt;
    public AudioSource keyPickUpSFX;


    void Start(){
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
        safekeyArt.SetActive(false);
        keyPickUpSFX = GetComponent<AudioSource>();
    }

    void Update(){
        if (gameHandler.hasGoldKey == true) {
            safekeyArt.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && gameHandler.hasGoldKey == true ){
            safekeyArt.SetActive(false);
            gameHandler.hasSafeKey = true;
            GetComponent<Collider2D>().enabled = false;
            keyPickUpSFX.Play();
            StartCoroutine(DelayDestroy());
        }
    }

    IEnumerator DelayDestroy(){
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    } 
}
