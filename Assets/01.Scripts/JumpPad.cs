using UnityEngine;

namespace _01.Scripts
{
    public class JumpPad : MonoBehaviour
    {
        Rigidbody m_rigidbody;

        public float power = 5.0f;

        void Start()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("JumpPad: OnCollisionEnter with " + collision.gameObject.name);

            if (!collision.gameObject.CompareTag("Player")) return;


            Rigidbody rb = collision.collider.attachedRigidbody;
            if (rb == null)
            {
                return;
            }

            rb.AddForce(Vector3.up * power, ForceMode.Impulse);

        }
    }
}
