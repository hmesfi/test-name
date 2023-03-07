using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_Gaze : MonoBehaviour {

       public bool isVertical = false;

       public float rotationSpeed = 30;
       public float distance = 2;
       public LineRenderer lineOfSight;
       public Gradient redColor;
       public Gradient greenColor;
       private Vector3 rayDirection;
       // public GameObject hitEffectAnim;

       // public int EnemyLives = 30;
       private Renderer rend;
       private GameHandler gameHandler;

	public LayerMask targetMask;
	public LayerMask obstructionMask;

       private bool canHit = true;
       private float coolDown = 0.5f;

       //public Transform tempCircle;

       void Start() {
              Physics2D.queriesStartInColliders = false;

              rend = GetComponentInChildren<Renderer>();

              if (GameObject.FindWithTag("GameHandler") != null) {
                     gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
              }
       }

       void FixedUpdate () {
              //transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);

              if (isVertical == false){
                     bool isRight = GetComponent<NPC_PatrolSequencePoints>().faceRight;
                     if (isRight){rayDirection = transform.right;}
                     else {rayDirection = -transform.right;}
              } else {
                     bool isRight = GetComponent<NPC_PatrolSequencePoints>().faceRight;
                     if (isRight){rayDirection = transform.up;}
                     else {rayDirection = -transform.up;}
              }

              // Raycast needs location, Direction, and length 
              RaycastHit2D hitInfo = Physics2D.Raycast (transform.position, rayDirection, distance);
              //tempCircle.position = hitInfo.point;
              //if (hitInfo.collider != null) {
              //   Debug.DrawLine(transform.position, hitInfo.point, Color.red);
              //   lineOfSight.SetPosition(1, hitInfo.point); // index 1 is the end-point of the line 
              //        lineOfSight.colorGradient = redColor;

              if ((hitInfo.collider.CompareTag ("Player"))&&(canHit)) {
                     Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                     lineOfSight.SetPosition(1, hitInfo.point); // index 1 is the end-point of the line 
                     lineOfSight.colorGradient = redColor;

                     //        // GameObject animEffect = Instantiate (hitEffectAnim, hitInfo.point, Quaternion.identity);
                     //        // Destroy(animEffect, 0.5f);
                     //        // Destroy (hitInfo.collider.gameObject);
                            //StopCoroutine("NPC_Sus");
                            StartCoroutine(NPC_Sus(1));
                            StartCoroutine(EnemyCoolDown());
                            Debug.Log("Oopsie. Guard saw me.");
              } else if (!hitInfo.collider.CompareTag ("Player")){
                     //Debug.DrawLine(transform.position, transform.position + rayDirection * distance, Color.green);
                     //lineOfSight.SetPosition(1, transform.position + rayDirection * distance);
                     Debug.DrawLine(transform.position, hitInfo.point, Color.green);
                     lineOfSight.SetPosition(1, hitInfo.point); // index 1 is the end-point of the line
                     
                     lineOfSight.colorGradient = greenColor;
              }
              lineOfSight.SetPosition (0, transform.position); 
              // index 0 is the start-point of the line
       }


        void OnTriggerEnter2D(Collider2D other){
               if ((other.gameObject.tag == "Player") && (canHit)) {
                     Debug.Log("Oopsie. Hit a guard.");
                      //EnemyLives -= 1;
                      //StopCoroutine("NPC_Sus");
                      StartCoroutine(NPC_Sus(2));
                      StartCoroutine(EnemyCoolDown());
               }
        }

       IEnumerator NPC_Sus(int amt){
              float pauseTime = 1f * amt;

              // color values are R, G, B, and alpha, each divided by 100
              rend.material.color = new Color(2.4f, 0.9f, 0.9f, 1f);
              gameHandler.SusChange(amt);
              
              yield return new WaitForSeconds(pauseTime);
              rend.material.color = Color.white;
       }

       IEnumerator EnemyCoolDown(){
              //Debug.DrawLine(transform.position, hitInfo.point, Color.red);
              lineOfSight.colorGradient = redColor;
              canHit = false;
              Debug.Log("canHit = " + canHit);
              yield return new WaitForSeconds(coolDown);
              canHit = true;
              Debug.Log("canHit = " + canHit);
              lineOfSight.colorGradient = greenColor;
              //Debug.DrawLine(transform.position, hitInfo.point, Color.green);
       }
}