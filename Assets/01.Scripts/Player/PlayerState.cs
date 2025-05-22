using _01.Scripts.UI;
using UnityEngine;

namespace _01.Scripts.Player
{
   public class PlayerState : MonoBehaviour
   {
      public UICondition uiCondition;

      Condition health
      {
         get { return uiCondition.health; }
      }

      void Update()
      {
         if (health.curValue <= 0)
         {
            Die();
         }
      }

      void Heal(float value)
      {
         health.Add(value);
      }

      void Die()
      {
         Debug.Log("플레이어가 사망했습니다.");
      }
   }
}