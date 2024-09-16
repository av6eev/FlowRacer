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
        public float MaxRotateAngle;
        public float RotateSpeed;
        public float CenteringAfterTurnMultiplier;
        public float TurnSlerpMultiplier;
    }
}