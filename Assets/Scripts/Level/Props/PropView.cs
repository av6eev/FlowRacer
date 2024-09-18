using System;
using Pulls;
using UnityEngine;

namespace Level.Props
{
    public class PropView : MonoBehaviour, IPullObject
    {
        public Collider Collider;
        [NonSerialized] public PropsType Type;
        
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