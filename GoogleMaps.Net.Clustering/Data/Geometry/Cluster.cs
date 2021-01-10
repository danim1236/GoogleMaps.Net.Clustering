using System.Collections.Generic;
using System.Linq;
using GoogleMaps.Net.Clustering.Data.Algo;
using JetBrains.Annotations;

namespace GoogleMaps.Net.Clustering.Data.Geometry
{
    public class Cluster : MapPoint
    {
        private readonly List<MapPoint> _mapPoints = new List<MapPoint>();

        [UsedImplicitly]
        public Cluster()
        {
        }

        private Cluster(MapPointBase centroid)
        {
            if (centroid != null)
            {
                X = centroid.X;
                Y = centroid.Y;
            }
        }

        public Cluster(IEnumerable<MapPoint> points, MapPoint mapPoint = null)
            : this(mapPoint)
        {
            _mapPoints = new List<MapPoint>(points.ToArray());
        }

        public Cluster(Bucket bucket)
            : this(bucket.Points, bucket.Centroid)
        {
        }

        public override int Count
        {
            get => _mapPoints.Count;
            set {}
        }

        [UsedImplicitly]
        public Cluster Add(MapPoint point)
        {
            _mapPoints.Add(point);
            return this;
        }

        [UsedImplicitly]
        public Cluster AddRange(IEnumerable<MapPoint> points)
        {
            _mapPoints.AddRange(points);
            return this;
        }

        [UsedImplicitly]
        public IEnumerable<MapPoint> GetMapPoints()
        {
            return _mapPoints;
        }
    }
}