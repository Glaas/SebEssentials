using UnityEngine;
using static UnityEngine.Mathf;

namespace SebEssentials
{
    public static class CurveLib
    {
        public static float Wave(float x, float t)
        {
            return Mathf.Sin(Mathf.PI * (x + t));
        }

        public static float EaseInOutCubic(float x)
        {
            return x < 0.5 ? 4 * x * x * x : 1 - Pow(-2 * x + 2, 3) / 2;
        }

        public static float EaseInSine(float x)
        {
            return 1 - Cos((x * PI) / 2);
        }

        public static float Remap(float lerpMin, float lerpMax, float invLerpmin, float invLerpMax, float invLerpdelta)
        {
            return Lerp(lerpMin, lerpMax, InverseLerp(invLerpmin, invLerpMax, invLerpdelta));
        }

        public static float EaseInOutExpo(float x)
        {
            return x == 0
                ? 0
                : x == 1
                    ? 1
                    : x < 0.5
                        ? Pow(2, 20 * x - 10) / 2
                        : (2 - Pow(2, -20 * x + 10)) / 2;
        }

    }
}