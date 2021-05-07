using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    
    

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

     [SerializeField]
     private float leftWrapAroundBound;
 
     //same as leftBound, just for the right side
     [SerializeField]
     private float rightWrapAroundBound;
     private  Rigidbody2D rigidBody2D;
     private void Awake() {
        rigidBody2D = GetComponent<Rigidbody2D>();
     }
      private void FixedUpdate()
     {
         //have not completed the work here yet
         float loopedAreaWidth = rightWrapAroundBound - leftWrapAroundBound;
 
         
         //get current position of the rigidbody
         Vector2 currentPosition = rigidBody2D.position;
 
         //move rigidbody into screen from the left bound if it is left of the left wrap around bound
         while (currentPosition.x < leftWrapAroundBound)
         {
             //add whole looped areaWidth so it reappears on the right side
             currentPosition.x += loopedAreaWidth;
         }
 
         //same as I did for the left bound, just mirrored for the right bound
         while (currentPosition.x > rightWrapAroundBound)
         {
             currentPosition.x -= loopedAreaWidth;
         }
 
         //write back modified position
         rigidBody2D.position = currentPosition;
     }
 
     
    void Update(){
        Swipe();
    }



    public void Swipe(){
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            startTouchPosition = Input.GetTouch(0).position;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if(Distance.x < -swipeRange){
               
                Debug.Log("left");
                stopTouch = true;
            }else if(Distance.x > swipeRange){
                
                Debug.Log("right");
                stopTouch = true;
            }else if(Distance.y > swipeRange){
              
             
                stopTouch = true;
            }else if(Distance.y > swipeRange){
                Debug.Log("down");
               
                stopTouch = true;
            }
        }
        
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended){
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if(Mathf.Abs(Distance.x)<tapRange && Mathf.Abs(Distance.y)< tapRange){
                
            }
        }
    }
}
