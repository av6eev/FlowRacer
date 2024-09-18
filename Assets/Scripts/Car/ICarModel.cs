using Car.Specification;
using Reactive.Field;
using UnityEngine;

namespace Car
{
    public interface ICarModel
    {
        CarSpecification Specification { get; }
        ReactiveField<float> CurrentSpeed { get; }
        ReactiveField<Vector3> CurrentPosition { get; }
    }
}