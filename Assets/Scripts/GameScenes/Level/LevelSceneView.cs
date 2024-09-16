using System;
using System.Collections.Generic;
using Cinemachine;
using Level.Props;
using UnityEngine;

namespace GameScenes.Level
{
    public class LevelSceneView : BaseGameSceneView
    {
        public Transform LevelRoot;
        public CinemachineVirtualCamera Camera;
        [NonSerialized] public readonly List<PropView> ActiveRoadElements = new();
    }
}