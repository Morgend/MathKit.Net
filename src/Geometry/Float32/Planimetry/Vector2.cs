﻿/*
 * Copyright 2019-2021 Andrey Pokidov <andrey.pokidov@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace Geometry.Float32.Planimetry
{
    public struct Vector2
    {
        public const float DEFAULT_COORDINATE_VALUE = 0.0f;
        public static readonly Vector2 ZERO_VECTOR = new Vector2(0.0f, 0.0f);

        public static readonly Vector2 UNIT_X_VECTOR = new Vector2(1.0f, 0.0f);
        public static readonly Vector2 UNIT_Y_VECTOR = new Vector2(0.0f, 1.0f);

        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
        }

        public void SetToZero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
        }

        public bool IsZero()
        {
            return x * x + y * y <= MathHelper.POSITIVE_SQUARE_FLOAT_EPSYLON;
        }

        public bool IsUnit()
        {
            float difference = x * x + y * y - 1.0f;
            return MathHelper.NEGATIVE_SQUARE_FLOAT_EPSYLON <= difference && difference <= MathHelper.POSITIVE_SQUARE_FLOAT_EPSYLON;
        }

        public void SetValues(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void CopyValuesFrom(Vector2 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
        }

        public void CopyValuesFrom(Geometry.Float64.Planimetry.Vector2 vector)
        {
            this.x = (float)vector.x;
            this.y = (float)vector.y;
        }

        public float Scalar(Vector2 vector)
        {
            return this.x * vector.x + this.y * vector.y;
        }

        public float Module()
        {
            return MathF.Sqrt(this.x * this.x + this.y * this.y);
        }

        public bool Normalize()
        {
            float squareModule = this.x * this.x + this.y * this.y;

            if (squareModule == 1.0)
            {
                return true;
            }

            if (squareModule == 0.0)
            {
                return false;
            }

            if (squareModule <= MathHelper.POSITIVE_SQUARE_FLOAT_EPSYLON)
            {
                this.SetToZero();
                return false;
            }

            float module = MathF.Sqrt(squareModule);

            this.x /= module;
            this.y /= module;

            return true;
        }

        public Vector2 GetNormalized()
        {
            Vector2 result = this;
            result.Normalize();
            return result;
        }

        public Vector2 Add(Vector2 vector, bool assign = false)
        {
            if (assign)
            {
                this.x += vector.x;
                this.y += vector.y;
                return this;
            }

            return new Vector2(this.x + vector.x, this.y + vector.y);
        }

        public Vector2 Subtract(Vector2 vector, bool assign = false)
        {
            if (assign)
            {
                this.x -= vector.x;
                this.y -= vector.y;
                return this;
            }

            return new Vector2(this.x - vector.x, this.y - vector.y);
        }

        public Vector2 Multiply(float value, bool assign = false)
        {
            if (assign)
            {
                this.x *= value;
                this.y *= value;
                return this;
            }

            return new Vector2(this.x * value, this.y * value);
        }

        public Vector2 Divide(float value, bool assign = false)
        {
            if (assign)
            {
                this.x /= value;
                this.y /= value;
                return this;
            }

            return new Vector2(this.x / value, this.y / value);
        }

        public void Reverse()
        {
            this.x = -this.x;
            this.y = -this.y;
        }

        public Vector2 GetReverted()
        {
            return new Vector2(-this.x, -this.y);
        }

        public Geometry.Float32.Planimetry.Vector2 ToFloat()
        {
            return new Geometry.Float32.Planimetry.Vector2((float)this.x, (float)this.y);
        }

        public bool IsEqualTo(Vector2 vector)
        {
            return MathHelper.AreEqual(this.x, vector.x) && MathHelper.AreEqual(this.y, vector.y);
        }

        public bool IsStrictlyEqualTo(Vector2 vector)
        {
            return this.x == vector.x && this.y == vector.y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static float operator *(Vector2 v1, Vector2 v2)
        {
            return v1.Scalar(v2);
        }

        public static Vector2 operator *(Vector2 vector, float value)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        public static Vector2 operator *(float value, Vector2 vector)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        public static Vector2 operator /(Vector2 vector, float value)
        {
            return new Vector2(vector.x / value, vector.y / value);
        }

        public static Vector2 operator -(Vector2 vector)
        {
            return new Vector2(-vector.x, -vector.y);
        }

        public override string ToString()
        {
            return String.Format("Float64.Vector2({0}, {1})", this.x, this.y);
        }
    }
}