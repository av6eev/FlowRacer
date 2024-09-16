using Car.Specification;
using Reactive.Field;
using UnityEngine;

namespace Car
{
    public class CarModel : ICarModel
    {
        public const float MinVerticalCoordinate = 1.2f;
        
        public CarSpecification Specification { get; }
        
        public ReactiveField<float> CurrentSpeed { get; } = new(0f);
        public ReactiveField<Vector3> CurrentPosition { get; } = new(new Vector3(0, MinVerticalCoordinate, 0));
        
        public bool IsReady;

        public CarModel(CarSpecification specification)
        {
            Specification = specification;
        }
    }
}