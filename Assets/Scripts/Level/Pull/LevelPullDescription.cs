using System;
using System.Collections.Generic;
using Level.Props;
using UnityEngine;

namespace Level.Pull
{
    [Serializable]
    public class LevelPullDescription
    {
        public PropsType Type;
        public int InitElementsCount;
        public List<GameObject> Prefabs;
        public string RootGoName;
    }
}