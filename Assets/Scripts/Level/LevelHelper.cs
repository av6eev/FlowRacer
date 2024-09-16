using Level.Props;
using UnityEngine;

namespace Level
{
    public static class LevelHelper
    {
        public static bool CheckOverlappingWithProps(PropView propElement, Vector3 supposedPosition)
        {
            var propTransform = propElement.transform;
            var overlapColliders = Physics.OverlapBox(supposedPosition, propElement.Collider.transform.lossyScale);

            foreach (var collider in overlapColliders)
            {
                var go = collider.gameObject;

                if (go.layer == LayerMask.NameToLayer("Prop") || go.layer == LayerMask.NameToLayer("Road"))
                {
                    return true;
                }
            }

            return false;
        }

        public static Vector3 GetRandomPosition(RoadView roadSegment)
        {
            var roadPositionZ = roadSegment.transform.position.z;
            var randomGrassSegmentBounds = roadSegment.GrassColliders[Random.Range(0, roadSegment.GrassColliders.Count)].bounds;
            var minX = randomGrassSegmentBounds.center.x - randomGrassSegmentBounds.extents.x;
            var maxX = randomGrassSegmentBounds.center.x + randomGrassSegmentBounds.extents.x;
            var minZ = roadPositionZ + (randomGrassSegmentBounds.center.z - randomGrassSegmentBounds.extents.z);
            var maxZ = roadPositionZ + (randomGrassSegmentBounds.center.z + randomGrassSegmentBounds.extents.z);
            var randomX = Random.Range(minX, maxX);
            var randomZ = Random.Range(minZ, maxZ);

            return new Vector3(randomX, 0, randomZ);
        }
    }
}