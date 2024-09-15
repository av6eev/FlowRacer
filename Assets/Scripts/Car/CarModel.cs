using Car.Specification;
using Reactive.Field;

namespace Car
{
    public class CarModel : ICarModel
    {
        public CarSpecification Specification { get; }
        public ReactiveField<float> CurrentSpeed { get; } = new(0f);

        public CarModel(CarSpecification specification)
        {
            Specification = specification;
        }
    }
}