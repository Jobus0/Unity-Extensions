using UnityEngine;

namespace Jobus.Extensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Get the vector with specified X.
        /// </summary>
        public static Vector3 WithX(this Vector3 vector3, float x)
        {
            return new Vector3(x, vector3.y, vector3.z);
        }

        /// <summary>
        /// Get the vector with specified Y.
        /// </summary>
        public static Vector3 WithY(this Vector3 vector3, float y)
        {
            return new Vector3(vector3.x, y, vector3.z);
        }

        /// <summary>
        /// Get the vector with specified Z.
        /// </summary>
        public static Vector3 WithZ(this Vector3 vector3, float z)
        {
            return new Vector3(vector3.x, vector3.y, z);
        }

        /// <summary>
        /// Get the vector with Y and Z at 0.
        /// </summary>
        public static Vector3 OnlyX(this Vector3 vector3)
        {
            return new Vector3(vector3.x, 0f, 0f);
        }

        /// <summary>
        /// Get the vector with X and Z at 0.
        /// </summary>
        public static Vector3 OnlyY(this Vector3 vector3)
        {
            return new Vector3(0f, vector3.y, 0f);
        }

        /// <summary>
        /// Get the vector with X and Y at 0.
        /// </summary>
        public static Vector3 OnlyZ(this Vector3 vector3)
        {
            return new Vector3(0f, 0f, vector3.z);
        }

        /// <summary>
        /// Get a Vector2 using the components of a Vector3's X and Y.
        /// </summary>
        public static Vector2 XY(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }
    
        /// <summary>
        /// Get a Vector2 using the components of a Vector3's X and Z.
        /// </summary>
        public static Vector2 XZ(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }
    
        /// <summary>
        /// Get a Vector2 using the components of a Vector3's Y and Z.
        /// </summary>
        public static Vector2 YZ(this Vector3 vector3)
        {
            return new Vector2(vector3.y, vector3.z);
        }

        /// <summary>
        /// Get the largest component of the vector.
        /// </summary>
        public static float Max(this Vector3 vector3, bool absolute = false)
        {
            if (absolute)
                return Mathf.Max(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y), Mathf.Abs(vector3.z));
            return Mathf.Max(vector3.x, vector3.y, vector3.z);
        }

        /// <summary>
        /// Get the largest component of the vector.
        /// </summary>
        public static float Max(this Vector2 vector2, bool absolute = false)
        {
            if (absolute)
                return Mathf.Max(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y));
            return Mathf.Max(vector2.x, vector2.y);
        }

        /// <summary>
        /// Get the smallest component of the vector.
        /// </summary>
        public static float Min(this Vector3 vector3, bool absolute = false)
        {
            if (absolute)
                return Mathf.Min(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y), Mathf.Abs(vector3.z));
            return Mathf.Min(vector3.x, vector3.y, vector3.z);
        }

        /// <summary>
        /// Get the smallest component of the vector.
        /// </summary>
        public static float Min(this Vector2 vector2, bool absolute = false)
        {
            if (absolute)
                return Mathf.Min(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y));
            return Mathf.Min(vector2.x, vector2.y);
        }

        /// <summary>
        /// Clamp each component of the vector.
        /// </summary>
        public static Vector3 ClampEach(this Vector3 vector3, float min, float max)
        {
            return new Vector3(Mathf.Clamp(vector3.x, min, max), Mathf.Clamp(vector3.y, min, max), Mathf.Clamp(vector3.z, min, max));
        }

        /// <summary>
        /// Divide each component of a vector with the respective components of another vector.
        /// </summary>
        public static Vector3 Divide(this Vector3 vector3, Vector3 divisionVector)
        {
            return new Vector3(vector3.x/divisionVector.x, vector3.y/divisionVector.y, vector3.z/divisionVector.z);
        }

        /// <summary>
        /// Divide each component of a vector with three different values.
        /// </summary>
        public static Vector3 Divide(this Vector3 vector3, float divisionX, float divisionY, float divisionZ)
        {
            return new Vector3(vector3.x/divisionX, vector3.y/divisionY, vector3.z/divisionZ);
        }

        /// <summary>
        /// Divide each component of a vector with the respective components of another vector.
        /// </summary>
        public static Vector3 Divide(this Vector2 vector2, Vector2 divisionVector)
        {
            return new Vector3(vector2.x/divisionVector.x, vector2.y/divisionVector.y);
        }

        /// <summary>
        /// Multiply each component of a vector with the respective components of another vector.
        /// </summary>
        public static Vector3 Multiply(this Vector3 vector3, Vector3 multiplicationVector)
        {
            return new Vector3(vector3.x*multiplicationVector.x, vector3.y*multiplicationVector.y, vector3.z*multiplicationVector.z);
        }

        /// <summary>
        /// Multiply each component of a vector with the respective components of another vector.
        /// </summary>
        public static Vector3 Multiply(this Vector2 vector2, Vector2 multiplicationVector)
        {
            return new Vector3(vector2.x*multiplicationVector.x, vector2.y*multiplicationVector.y);
        }
    
        /// <summary>
        /// Wraps the float so that 0 to 360 becomes -180 to 180.
        /// </summary>
        public static float NegativeAngle(this float v)
        {
            return Mathf.Repeat(v + 180f, 360f) - 180f;;
        }

        /// <summary>
        /// Wraps the vector's components so that 0 to 360 becomes -180 to 180.
        /// </summary>
        public static Vector3 NegativeAngles(this Vector3 v)
        {
            for (int i = 0; i < 2; i++)
                v[i] = NegativeAngle(v[i]);

            return v;
        }

        /// <summary>
        /// Normalizes value to either -1, 0, or 1.
        /// </summary>
        public static float Normalize(this float value)
        {
            if (value < 0f) return -1f;
            if (value > 0f) return 1f;
            return 0f;
        }
    
        /// <summary>
        /// Get the maximum possible value of the curve.
        /// </summary>
        public static float Max(this ParticleSystem.MinMaxCurve curve)
        {
            switch (curve.mode)
            {
                case ParticleSystemCurveMode.Constant:
                    return curve.constant;
                case ParticleSystemCurveMode.Curve:
                {
                    float max = 0f;
                    for (int i = 0; i < curve.curve.length; i++)
                        max = Mathf.Max(max, curve.curve[i].value);
                    return max;
                }
                case ParticleSystemCurveMode.TwoCurves:
                {
                    float max = 0f;
                    for (int i = 0; i < curve.curveMax.length; i++)
                        max = Mathf.Max(max, curve.curveMax[i].value);
                    return max;
                }
                case ParticleSystemCurveMode.TwoConstants:
                    return Mathf.Max(curve.constantMin, curve.constantMax);
            }
            return 0f;
        }

        /// <summary>
        /// Get the minimum possible value of the curve.
        /// </summary>
        public static float Min(this ParticleSystem.MinMaxCurve curve)
        {
            switch (curve.mode)
            {
                case ParticleSystemCurveMode.Constant:
                    return curve.constant;
                case ParticleSystemCurveMode.Curve:
                {
                    float min = 0f;
                    for (int i = 0; i < curve.curve.length; i++)
                        min = Mathf.Min(min, curve.curve[i].value);
                    return min;
                }
                case ParticleSystemCurveMode.TwoCurves:
                {
                    float min = 0f;
                    for (int i = 0; i < curve.curveMax.length; i++)
                        min = Mathf.Min(min, curve.curveMin[i].value);
                    return min;
                }
                case ParticleSystemCurveMode.TwoConstants:
                    return Mathf.Min(curve.constantMin, curve.constantMax);
            }
            return 0f;
        }

        /// <summary>
        /// Returns a scaled MinMaxCurve, scaling the correct value for the selected CurveMode.
        /// </summary>
        public static ParticleSystem.MinMaxCurve Scale(this ParticleSystem.MinMaxCurve curve, float scale)
        {
            switch (curve.mode)
            {
                case ParticleSystemCurveMode.Constant:
                    curve.constant *= scale;
                    break;
                case ParticleSystemCurveMode.TwoCurves:
                case ParticleSystemCurveMode.Curve:
                    curve.curveMultiplier *= scale;
                    break;
                case ParticleSystemCurveMode.TwoConstants:
                    curve.constantMin *= scale;
                    curve.constantMax *= scale;
                    break;
            }
            return curve;
        }

        /// <summary>
        /// Collects a number (default: 100) of evaluation samples and returns the average. 
        /// </summary>
        /// <param name="samples">Number of samples to average. Higher value gives a more accurate average, but is slower to calculate.</param>
        /// <param name="deterministic">Use seed of 0 to make the result deterministic (non-changing if run multiple times). Previous Random.state will be restored.</param>
        public static float EvaluateAverage(this AnimationCurve curve, int samples = 100, bool deterministic = true)
        {
            var lastState = Random.state;
            Random.InitState(0);

            float max = curve.keys[curve.keys.Length - 1].time;

            float average = 0f;
            for (int i = 0; i < samples; i++)
                average += curve.Evaluate(Random.value*max);
            average /= samples;

            Random.state = lastState;

            return average;
        }
    }
}