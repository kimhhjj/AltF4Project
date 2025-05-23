using System.Collections;
using System.Collections.Generic;
using _01.Scripts.Data;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public Inventory inventory;       // 인벤토리 연결
    public ItemData itemToGive;       // 줄 아이템
    public KeyCode giveKey = KeyCode.G; // 누를 키
    public UIInventory uiInventory;

    void Update()
    {
        if (Input.GetKeyDown(giveKey))
        {
            if (inventory != null && itemToGive != null)
            {
                if (inventory.items.Count >= uiInventory.slotMaxCount)
                {
                    Debug.Log("가방이 가득차서 아이템 지급이 안됩니다.");
                }
                else
                {
                    inventory.AddItem(itemToGive);
                    Debug.Log("아이템 지급됨: " + itemToGive.itemName);


                    if (uiInventory != null)
                        uiInventory.RefreshUI(); // ← UI 갱신!
                }


            }
        }
    }
}
