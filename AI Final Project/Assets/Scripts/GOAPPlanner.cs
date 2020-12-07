using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

class TreeNode
{
   public TreeNode(TreeNode parent, GOAPAction selected, float actionCost, HashSet<KeyValuePair<string, object>> worldState)
   {
      previous = parent;
      action = selected;
      cost = actionCost;
      wStateAtNode = worldState;
   }

   TreeNode previous;
   GOAPAction action;
   float cost;
   HashSet<KeyValuePair<string, object>> wStateAtNode;
}


public class GOAPPlanner : MonoBehaviour
{


   public Queue<GOAPAction> CreatePlan(GameObject agent, HashSet<GOAPAction> availableActions, HashSet<KeyValuePair<string, object>> worldState, HashSet<KeyValuePair<string, object>> agentGoals )
   {

      //reset actions
      foreach (GOAPAction action in availableActions)
      {
         action.doReset();
      }

      HashSet<GOAPAction> usableActions = new HashSet<GOAPAction>();
      //get actions that can be used
      foreach (GOAPAction action in availableActions)
      {
         if (action.checkProceduralPrecondition(agent))
         {
            usableActions.Add(action);
         }
      }

      //Build decision tree
      List<TreeNode> actionTree = new List<TreeNode>();

      actionTree.Add(new TreeNode(null, null, 0, worldState));

      

      //form queue in proper order



      return new Queue<GOAPAction>();
   }


   bool findActionsToGoal(HashSet<KeyValuePair<string, object>> agentGoals, List<TreeNode> actionTree, HashSet<GOAPAction> usableActions)
   {

      foreach (GOAPAction action in usableActions)
      {

         if (true)
         {

         }



      }








      return true;
   }


   bool conditionsMet(HashSet<KeyValuePair<string, object>> check, HashSet<KeyValuePair<string, object>> inside)
   {
      bool success = true;

      foreach (KeyValuePair<string, object> i in check)
      {
         bool match = false;

         foreach (KeyValuePair<string, object> j in inside)
         {
            
            if (i.Equals(j))
            {
               match = true;
               break;
            }


         }

         if (match == false)
         {
            
         }


      }




      return true;
   }


   public HashSet<KeyValuePair<string, object>> updateState()
   {




      return new HashSet<KeyValuePair<string, object>>();
   }


}
