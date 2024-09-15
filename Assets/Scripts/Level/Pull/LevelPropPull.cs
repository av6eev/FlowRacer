using Level.Props;
using Pulls;
using UnityEngine;

namespace Level.Pull
{
    public class LevelPropPull : Pull<PropView>
    {
        public readonly LevelPullDescription Description;
        private readonly Transform _root;
        
        public LevelPropPull(LevelPullDescription description)
        {
            Description = description;
            _root = GameObject.Find(description.RootGoName).transform;
        }
        
        protected override PropView CreateElement()
        {
            var randomElementIndex = Random.Range(0, Description.Prefabs.Count);
            var element = Description.Prefabs[randomElementIndex];
            var go = Object.Instantiate(element, _root).GetComponent<PropView>();
            
            ModifyPutObject(go);
            return go;
        }

        protected override void ModifyPutObject(PropView element)
        {
            element.Hide();
        }

        protected override void ModifyGetObject(PropView element)
        {
            element.Show();
        }

        protected override void RemoveElement(PropView element)
        {
            Object.Destroy(element);
        }
    }
}