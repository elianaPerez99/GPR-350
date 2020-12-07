using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
   GET_GOAL,
   MOVE_TO,
   ACTION,
   STATE_COUNT
};

public class FiniteStateMachine : MonoBehaviour
{
   public delegate void FSMStateDel();

   FSMStateDel currentState;

   public void update()
   {
      if (currentState != null)
      {
         currentState();

      }

   }

   public void setState(FSMStateDel newState)
   {
      currentState = newState;
   }

}
