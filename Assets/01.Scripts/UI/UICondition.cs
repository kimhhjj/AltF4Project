using _01.Scripts.Player;
using UnityEngine;

namespace _01.Scripts.UI
{
   public class UICondition : MonoBehaviour
   {
      public Condition health;

      void Start()
      {
         PlayerManager.Instance.Player.playerState.uiCondition = this;
      }


   }
}
