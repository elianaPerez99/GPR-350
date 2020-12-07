using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAPAgent : MonoBehaviour//, GOAPInterface
{

   FiniteStateMachine fsm;

   HashSet<GOAPAction> actionOptions;
   Queue<GOAPAction> agentActions;

   GOAPPlanner planner;

   FiniteStateMachine.FSMStateDel idleInst;
   FiniteStateMachine.FSMStateDel moveInst;
   FiniteStateMachine.FSMStateDel performInst;
   

   private void Start()
   {
      actionOptions = new HashSet<GOAPAction>();
      fsm = new FiniteStateMachine();
      planner = new GOAPPlanner();
      

      fsm.setState(idleInst);
      GetActions();


   }

   private void Update()
   {
      fsm.update();
   }

   



   void GetActions()
   {
      foreach (GOAPAction action in GetComponents<GOAPAction>())
      {
         actionOptions.Add(action);
      }
   }

   public void initIdleState()
   {
      idleInst = () => { 





      };
   }


   public void moveToState()
   {
      moveInst = () => {





      };

   }

   public void performState()
   {
      performInst = () =>
      {


      };

   }
}
