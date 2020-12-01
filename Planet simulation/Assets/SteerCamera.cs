using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerCamera : MonoBehaviour
{

   public float panSpeed;
   public float rotSpeed;

   public float damp;

   Rigidbody rb;

    void Awake()
    {
       rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
       HandleInput();
    }


   void HandleInput()
   {

      /*  Handle Camera Movement  */

      if (Input.GetKey(KeyCode.W))
      {
         MoveForward(panSpeed);
      }
      else if (Input.GetKey(KeyCode.S))
      {
         MoveForward(-panSpeed);
      }
     
      if (Input.GetKey(KeyCode.D))
      {
         MoveRight(panSpeed);
      }
      else if (Input.GetKey(KeyCode.A))
      {
         MoveRight(-panSpeed);
      }

      if (Input.GetKey(KeyCode.Q))
      {
         MoveUp(panSpeed);
      }
      else if (Input.GetKey(KeyCode.E))
      {
         MoveUp(-panSpeed);
      }

      if (rb.velocity.magnitude <= 1)
      {
         rb.velocity = new Vector3();
      }
      else
      {
         rb.velocity *= damp;
      }


      /*  Handle Camera Rotation  */

      if (Input.GetKey(KeyCode.Z))
      {
         RotateY(-rotSpeed);
      }
      else if (Input.GetKey(KeyCode.C))
      {
         RotateY(rotSpeed);
      }

      if (rb.angularVelocity.magnitude <= 1)
      {
         rb.angularVelocity = new Vector3();
      }
      else
      {
         rb.angularVelocity *= damp;
      }

   }

   void MoveForward(float speed)
   {
      rb.velocity += transform.forward * speed;
   }
   void MoveRight(float speed)
   {
      rb.velocity += transform.right * speed;
   }
   void MoveUp(float speed)
   {
      rb.velocity += transform.up * speed;
   }
   void RotateY(float speed)
   {
      rb.angularVelocity += new Vector3(0, speed, 0);
   }

}
