using System.Collections;
using System.Collections.Generic;
using _01.Scripts.Data;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public UIInventory uiInventory;

    public void AddItem(ItemData item)
    {

        if (items.Count >= uiInventory.slotMaxCount)
        {
           Debug.Log("가방이 가득 찼습니다.");
           Debug.Log(items.Count);
           return;
        }
        items.Add(item);
        Debug.Log("아이템이 추가됨");    
    }

    public void UseItem(int index, GameObject player)
    {
        items[index].effect.Apply(player);
        Debug.Log("아이템 사용: " + items[index].itemName);
    }
}
