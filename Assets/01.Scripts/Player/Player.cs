using UnityEngine;

namespace _01.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        public PlayerController controller;
        public PlayerState playerState;
    
        void Awake()
        {
            PlayerManager.Instance.Player = this;
            controller = GetComponent<PlayerController>();
            playerState = GetComponent<PlayerState>();
        }
    }
}
