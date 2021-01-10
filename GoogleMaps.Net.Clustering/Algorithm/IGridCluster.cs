using System.Collections.Generic;
using GoogleMaps.Net.Clustering.Data.Geometry;

namespace GoogleMaps.Net.Clustering.Algorithm
{
    internal interface IGridCluster
    {
        IList<Cluster> RunCluster();

        IList<Line> GetPolyLines(); // Google Maps debug lines
    }
}
