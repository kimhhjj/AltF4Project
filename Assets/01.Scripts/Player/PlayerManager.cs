using UnityEngine;

namespace _01.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private static PlayerManager _instance;

        public static PlayerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject(name:"PlayerManager").AddComponent<PlayerManager>();
                }
                return _instance;
            }
        }

        public global::_01.Scripts.Player.Player _player;

        public global::_01.Scripts.Player.Player Player
        {
            get{return _player;}
            set{_player = value;}
        }


        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (_instance != this)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
