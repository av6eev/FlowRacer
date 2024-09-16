using UnityEngine;

namespace Car
{
    public class CarView : MonoBehaviour
    {
        public GameObject Root;
        public Rigidbody Rigidbody;
        
        public Quaternion Rotation => Root.transform.rotation;
        public Vector3 Position
        {
            get => Root.transform.position;
            set => Root.transform.position = value;
        }

        public void Move(float speed)
        {
            Rigidbody.AddForce(Rigidbody.transform.forward * speed);
        }

        public void Turn(Vector3 direction)
        {
            Rigidbody.velocity = direction;
        }

        public void SetStartPosition(Vector3 startPosition)
        {
            Root.transform.position = startPosition;
        }

        public void Rotate(Quaternion direction)
        {
            Root.transform.rotation = direction;
        }
    }
}