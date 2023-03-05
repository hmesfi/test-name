using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_Gaze : MonoBehaviour {

       //public float rotationSpeed = 30;
       public float distance = 20;
       public LineRenderer lineOfSight;
       public Gradient redColor;
       public Gradient greenColor;
       // public GameObject hitEffectAnim;

       // public int EnemyLives = 30;
       private Renderer rend;
       private GameHandler gameHandler;

	public LayerMask targetMask;
	public LayerMask obstructionMask;

       void Start() {
              Physics2D.queriesStartInColliders = false;

              rend = GetComponentInChildren<Renderer>();

              if (GameObject.FindWithTag("GameHandler") != null) {
                     gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
              }
       }

       void FixedUpdate () {
              //transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);

              Vector3 rayDirection = transform.right;
              bool isRight = GetComponent<NPC_PatrolSequencePoints>().faceRight;
              if (isRight){rayDirection = transform.right;}
              else {rayDirection = -transform.right;}

              // Raycast needs location, Direction, and length 
              RaycastHit2D hitInfo = Physics2D.Raycast (transform.position, rayDirection, distance);
              //if (hitInfo.collider != null) {
              //   Debug.DrawLine(transform.position, hitInfo.point, Color.red);
              //   lineOfSight.SetPosition(1, hitInfo.point); // index 1 is the end-point of the line 
              //        lineOfSight.colorGradient = redColor;

              if (hitInfo.collider.CompareTag ("Player")) {
                     Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                     lineOfSight.SetPosition(1, hitInfo.point); // index 1 is the end-point of the line 
                     lineOfSight.colorGradient = redColor;
                     //        // GameObject animEffect = Instantiate (hitEffectAnim, hitInfo.point, Quaternion.identity);
                     //        // Destroy(animEffect, 0.5f);
                     //        // Destroy (hitInfo.collider.gameObject);
                            StopCoroutine("NPC_Sus");
                            StartCoroutine(NPC_Sus(1));
              } else {
                     //Debug.DrawLine(transform.position, transform.position + rayDirection * distance, Color.green);
                     //lineOfSight.SetPosition(1, transform.position + rayDirection * distance);
                     Debug.DrawLine(transform.position, hitInfo.point, Color.green);
                     lineOfSight.SetPosition(1, hitInfo.point); // index 1 is the end-point of the line
                     
                     lineOfSight.colorGradient = greenColor;
              }
              lineOfSight.SetPosition (0, transform.position); 
              // index 0 is the start-point of the line
       }


        void OnCollisionEnter2D(Collision2D collision){

               if (collision.gameObject.tag == "Player") {
                      //EnemyLives -= 1;
                      StopCoroutine("NPC_Sus");
                      StartCoroutine(NPC_Sus(4));
               }
        }

       IEnumerator NPC_Sus(int amt){
              float pauseTime = 0.5f * amt;
              // color values are R, G, B, and alpha, each divided by 100
              rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
              //if (EnemyLives < 1){
              //       gameControllerObj.AddScore (10);
              //       Destroy(gameObject);
              //}
              //else {
                     yield return new WaitForSeconds(pauseTime);
                     rend.material.color = Color.white;
              //}
       }
}