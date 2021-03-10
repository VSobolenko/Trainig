using System;

namespace External_training
{
    public class Vector3
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        private double _lenthVector;
        public double LenthVector
        {
            get
            {
                return _lenthVector;
            }
            private set
            {
                _lenthVector = value;
            }
        }

        public Vector3()
        {
            this.x = 0; this.y = 0; this.z = 0;
        }

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static double Angle(Vector3 a, Vector3 b)
        {
            double numerator = a.x * b.x + a.y * b.y + a.z * b.z;
            double denumerator = Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z) * Math.Sqrt(b.x * b.x + b.y * b.y + b.z * b.z);
            double angle = numerator / denumerator;
            return angle;
        }
        public static double Distance(Vector3 a, Vector3 b)
        {
            double denumerator = Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2) + Math.Pow(b.z - a.z, 2);
            double distance = Math.Sqrt(denumerator);
            return distance;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(a.x * -1, a.y * -1, a.z * -1);

        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

        }
        public static Vector3 operator *(Vector3 a, float d)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);

        }
        public static Vector3 operator *(float d, Vector3 a)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }
        public static Vector3 operator /(Vector3 a, float d)
        {
            return new Vector3(a.x / d, a.y / d, a.z / d);
        }
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            if (lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
