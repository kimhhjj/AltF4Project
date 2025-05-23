using UnityEngine;

namespace _01.Scripts.Data
{
    public enum ItemType
    {
        Consumable
    }
    
    
    
    [CreateAssetMenu(fileName = "NewItem",  menuName = "Items/New Item")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public string description;
        public Sprite icon;
        public ItemType type;
        public int amount;
        public int cost;
        public ItemEffect effect;

    }
}
