﻿using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct Quaternion
    {
        public const double DEFAULT_COORDINATE_VALUE = 0.0;

        public double x;
        public double y;
        public double z;
        public double w;

        public Quaternion(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void setValue(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void setValue(Quaternion q)
        {
            this.x = q.x;
            this.y = q.y;
            this.z = q.z;
            this.w = q.w;
        }

        public void zero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
            this.w = DEFAULT_COORDINATE_VALUE;
        }

        public void conjugate()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public Quaternion getConjugated()
        {
            return new Quaternion(-this.x, -this.y, -this.z, this.w);
        }

        public double module()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
        }

        public void normalize()
        {
            double module = this.module();

            if (module < MathConst.EPSYLON)
            {
                this.zero();
                return;
            }

            this.x /= module;
            this.y /= module;
            this.z /= module;
            this.w /= module;
        }

        public Quaternion multiply(Quaternion q)
        {
            return new Quaternion(
                this.y * q.z - this.z * q.y + this.w * q.x + this.x * q.w,
                this.x * q.z - this.z * q.x + this.w * q.y + this.y * q.w,
                this.x * q.y - this.y * q.x + this.w * q.z + this.z * q.w,
                this.w * q.w - this.x * q.x - this.y * q.y - this.z * q.z
            );
        }

        public void multiplyAt(Quaternion q)
        {
            this.setValue(
                this.y * q.z - this.z * q.y + this.w * q.x + this.x * q.w,
                this.x * q.z - this.z * q.x + this.w * q.y + this.y * q.w,
                this.x * q.y - this.y * q.x + this.w * q.z + this.z * q.w,
                this.w * q.w - this.x * q.x - this.y * q.y - this.z * q.z
            );
        }

        public void setMultiplicationOf(Quaternion q1, Quaternion q2)
        {
            this.setValue(
                q1.y * q2.z - q1.z * q2.y + q1.w * q2.x + q1.x * q2.w,
                q1.x * q2.z - q1.z * q2.x + q1.w * q2.y + q1.y * q2.w,
                q2.x * q2.y - q1.y * q2.x + q1.w * q2.z + q1.z * q2.w,
                q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z
            );
        }

        public Quaternion multiply(double value)
        {
            return new Quaternion(this.x * value, this.y * value, this.z * value, this.w * value);
        }

        public void multiplyAt(double value)
        {
            this.x *= value;
            this.y *= value;
            this.z *= value;
            this.w *= value;
        }

        public Quaternion divide(double value)
        {
            return new Quaternion(this.x / value, this.y / value, this.z / value, this.w / value);
        }

        public void divideAt(double value)
        {
            this.x /= value;
            this.y /= value;
            this.z /= value;
            this.w /= value;
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return q1.multiply(q2);
        }

        public static Quaternion operator *(Quaternion quaternion, double value)
        {
            return quaternion.multiply(value);
        }

        public static Quaternion operator *(double value, Quaternion quaternion)
        {
            return quaternion.multiply(value);
        }

        public static Quaternion operator /(Quaternion quaternion, double value)
        {
            return quaternion.divide(value);
        }

        public static Quaternion operator -(Quaternion q)
        {
            return q.getConjugated();
        }

        public override string ToString()
        {
            return String.Format("Quaternion(w: {0}, x: {1}, y: {2}, z: {3})", this.w, this.x, this.y, this.z);
        }
    }
}