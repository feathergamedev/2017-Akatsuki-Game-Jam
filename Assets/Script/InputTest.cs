using UnityEngine;  
 using System.Collections;  
   
 public class InputTest : MonoBehaviour {  
     protected float m_JoyX = 0.0f;  
     protected float m_JoyY = 0.0f;  
       
     // Use this for initialization  
     void Start () {  
       
     }  
       
     // Update is called once per frame  
     void Update ()   
     {          
         m_JoyX = Input.GetAxis("Horizontal");  
         m_JoyY = Input.GetAxis("Vertical");  
           
         if( Input.GetButton("Horizontal") )  
         {  
             Debug.Log("Get Horizontal input from Joystick = " + m_JoyX.ToString());  
         }else if(Input.GetButton("Vertical")) {  
             Debug.Log("GetVertical input from Joystick = " + m_JoyY.ToString());  
         }  
           
         if( Input.GetKey(KeyCode.JoystickButton11) ){  
             print("Get Joystick Button 0");  
         }  
           
         //Debug.Log("Get Horizontal input from Joystick = " + m_JoyX.ToString());  
     }  
 }  