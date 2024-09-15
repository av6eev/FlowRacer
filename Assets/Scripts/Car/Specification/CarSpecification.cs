using System;
using Specification;

namespace Car.Specification
{
    [Serializable]
    public class CarSpecification : BaseSpecification
    {
        public string PrefabId;
        public float MoveSpeed;
        public float TurnSpeed;
    }
}