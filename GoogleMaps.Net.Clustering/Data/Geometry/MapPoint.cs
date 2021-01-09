using GoogleMaps.Net.Clustering.Extensions;
using GoogleMaps.Net.Clustering.Utility;
using System;
using System.Runtime.Serialization;

namespace GoogleMaps.Net.Clustering.Data.Geometry
{
    /// <summary>
    /// Point class, overwrite it, modify it, extend it as you like
    /// </summary>    
    [Serializable]
    public class MapPoint : MapPointBase, ISerializable, IMapPoint
    {
        public MapPoint()
        {
        }

        public MapPoint(double x, double y) : this()
        {
            X = x;
            Y = y;
        }

        public virtual MapPoint Normalize()
        {
            Long = Long.NormalizeLongitude();
            Lat = Lat.NormalizeLatitude();
            return this;
        }

        // Dist between two points on Earth
        public new virtual double Distance(double x, double y)
        {
            return MathTool.Haversine(this.Y, this.X, y, x);
        }

        public override string ToString()
        {
            return $"Uid: {Uid}, X:{X}, Y:{Y}, MarkerType:{MarkerType}, MarkerId:{MarkerId}";
        }

        // Used for e.g. serialization to file
        public MapPoint(SerializationInfo info, StreamingContext ctxt)
        {
            Count = 1;
            MarkerId = (int)info.GetValue("MarkerId", typeof(int));
            MarkerType = (int)info.GetValue("MarkerType", typeof(int));
            X = ((string)info.GetValue("X", typeof(string))).ToDouble();
            Y = ((string)info.GetValue("Y", typeof(string))).ToDouble();
        }

        // Data returned as Json
        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("MarkerId", MarkerId);
            info.AddValue("MarkerType", MarkerType);
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Count", Count);
        }

        public int CompareTo(MapPoint other, int dimension)
        {
            switch (dimension)
            {
                case 0:
                    return X.CompareTo(other.X);
                case 1:
                    return Y.CompareTo(other.Y);
                default:
                    throw new ArgumentException("Invalid dimension.");
            }
        }
    }
}
