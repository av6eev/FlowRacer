using Specifications;
using UnityEngine;

namespace Car.Specification
{
    [CreateAssetMenu(menuName = "Create Specification Collection/New Car Collection", fileName = "CarCollectionSpecification", order = 51)]
    public class CarCollectionSpecificationScrObj : SpecificationCollectionScrObj<CarSpecification>
    {
    }
}