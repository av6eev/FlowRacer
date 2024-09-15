using UnityEngine;

namespace Level.Props
{
    public class PropView : MonoBehaviour
    {
        public Transform EndPoint;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}