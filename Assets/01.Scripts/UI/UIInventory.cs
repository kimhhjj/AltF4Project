using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
   public GameObject itemSlotPrefab;
   public Transform slotParent;
   public Inventory inventory;
   public int slotMaxCount = 20;
   
   public Color defaultColor = Color.gray;
   public Color occupiedColor = Color.white;
   
   void Start()
   {
      RefreshUI();
   }

   public void RefreshUI()
   {
      // 기존 슬롯 제거
      foreach (Transform child in slotParent)
      {
         Destroy(child.gameObject);
      }

      // 슬롯 채우기
      for (int i = 0; i < slotMaxCount; i++) // 슬롯 24개 고정 예시
      {
         var slot = Instantiate(itemSlotPrefab, slotParent);
         Image iconImage = slot.transform.Find("Icon").GetComponent<Image>();
         Image background = slot.GetComponent<Image>();

         // 슬롯에 아이템이 있으면 정보 채우기
         if (i < inventory.items.Count && inventory.items[i] != null)
         {
            iconImage.sprite = inventory.items[i].icon;
            iconImage.color = Color.white;
            background.color = occupiedColor;
         }
         else
         {
            iconImage.sprite = null;
            iconImage.color = Color.clear;
            background.color = defaultColor;
         }
      }
   }
}
