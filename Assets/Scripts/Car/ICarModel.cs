using Car.Specification;
using Reactive.Field;

namespace Car
{
    public interface ICarModel
    {
        ReactiveField<float> CurrentSpeed { get; }
        CarSpecification Specification { get; }
    }
}