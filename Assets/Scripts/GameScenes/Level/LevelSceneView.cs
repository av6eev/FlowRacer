using System;
using System.Collections.Generic;
using Level.Props;
using UnityEngine;

namespace GameScenes.Level
{
    public class LevelSceneView : BaseGameSceneView
    {
        public Transform LevelRoot;
        [NonSerialized] public readonly List<PropView> ActiveRoadElements = new();
    }
}