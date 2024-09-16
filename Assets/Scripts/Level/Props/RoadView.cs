using System.Collections.Generic;
using UnityEngine;

namespace Level.Props
{
    public class RoadView : PropView
    {
        public Transform EndPoint;
        public List<Collider> GrassColliders;
        public List<PropView> ActiveProps;
    }
}