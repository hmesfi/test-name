using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : MonoBehaviour
{
    private GameHandler gameHandler;
    public AudioSource keyPickUpSFX;
    public GameObject keyArt;

    void Start(){
        if (GameObject.FindWithTag("GameHandler") != null){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        }
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            Debug.Log("key stepped on");
            keyArt.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
            gameHandler.hasGoldKey = true;
            gameHandler.DisplayKeys(true);
            keyPickUpSFX.Play();
            StartCoroutine(DelayDestroy());
        }
    }

    IEnumerator DelayDestroy(){
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}
