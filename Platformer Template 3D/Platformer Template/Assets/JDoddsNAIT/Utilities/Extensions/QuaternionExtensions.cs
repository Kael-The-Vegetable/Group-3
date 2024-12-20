using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDoddsNAIT.Utilities.Extensions
{
    public static class QuaternionExtensions
    {
        public static Vector3 Forward(this Quaternion q) => q * Vector3.forward;
        public static Vector3 Back(this Quaternion q) => q * Vector3.back;
        public static Vector3 Right(this Quaternion q) => q * Vector3.right;
        public static Vector3 Left(this Quaternion q) => q * Vector3.left;
        public static Vector3 Up(this Quaternion q) => q * Vector3.up;
        public static Vector3 Down(this Quaternion q) => q * Vector3.down;

        // Quaternion math
        public static Quaternion Add(this Quaternion a, Quaternion b) => Quaternion.Euler(a.eulerAngles + b.eulerAngles);

        public static Quaternion Scale(this Quaternion q, float s) => Quaternion.Euler(q.eulerAngles * s);
    }
}