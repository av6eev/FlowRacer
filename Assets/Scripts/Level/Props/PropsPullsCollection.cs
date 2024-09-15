using System.Collections.Generic;
using Awaiter;
using Level.Pull;

namespace Level.Props
{
    public class PropsPullsCollection
    {
        private readonly Dictionary<PropsType, LevelPropPull> _pulls = new();
        public readonly CustomAwaiter IsInitialized = new();
        
        public void Add(LevelPullDescription description)
        {
            _pulls.Add(description.Type, new LevelPropPull(description));
        }
        
        public void InitAll()
        {
            foreach (var pull in _pulls.Values)
            {
                pull.Init(pull.Description.InitElementsCount);
            }
            
            IsInitialized.Complete();
        }

        public void DisposeAll()
        {
            foreach (var pull in _pulls.Values)
            {
                pull.Dispose();
            }
        }

        public bool TryGetPull(PropsType type, out LevelPropPull pull)
        {
            if (_pulls.TryGetValue(type, out var value))
            {
                pull = value;
                return true;
            }

            pull = null;
            return false;
        }
    }
}