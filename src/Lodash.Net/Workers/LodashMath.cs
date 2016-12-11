﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Lodash.Net.Extensions;
using Lodash.Net.Workers.Abstract;

namespace Lodash.Net.Workers
{
    public class LodashMath : ILodashMath
    {
        public double Add(double augend, double addend) => augend + addend;

        public double Ceil(double number, int precision = 0)
        {
            var precisionFactor = Math.Pow(10, precision);
            return Math.Ceiling(number * precisionFactor) / precisionFactor;
        }

        public double Divide(double dividend, double divisor) => dividend / divisor;

        public double Floor(double number, int precision = 0)
        {
            var precisionFactor = Math.Pow(10, precision);
            return Math.Floor(number * precisionFactor) / precisionFactor;
        }

        public T Max<T>(IEnumerable<T> enumerable) => enumerable.Max();

        public TResult MaxBy<TSource, TResult>(IEnumerable<TSource> enumerable, Func<TSource, TResult> iteratee) => enumerable.Max(iteratee);

        public T MaxBy<T>(IEnumerable<T> enumerable, string iteratee)
        {
            Func<T, object> func = item => typeof(T).GetTypeInfo().GetProperty(iteratee).GetValue(item);
            return (T)MaxBy(enumerable, func);
        }

        public double Mean<T>(IEnumerable<T> enumerable) => typeof(T).IsNumeric() ? enumerable.Cast<double>().Average() : double.NaN;

        public double MeanBy<T>(IEnumerable<T> enumerable, Func<T, double> iteratee) => enumerable.Average(iteratee);

        public double MeanBy<T>(IEnumerable<T> enumerable, string iteratee)
        {
            Func<T, double> func = item => (double)typeof(T).GetTypeInfo().GetProperty(iteratee).GetValue(item);
            return MeanBy(enumerable, func);
        }

        public T Min<T>(IEnumerable<T> enumerable) => enumerable.Min();

        public TResult MinBy<TSource, TResult>(IEnumerable<TSource> enumerable, Func<TSource, TResult> iteratee) => enumerable.Min(iteratee);

        public T MinBy<T>(IEnumerable<T> enumerable, string iteratee)
        {
            Func<T, object> func = item => typeof(T).GetTypeInfo().GetProperty(iteratee).GetValue(item);
            return (T)MinBy(enumerable, func);
        }

        public double Multiply(double multiplier, double multiplicand) => multiplier * multiplicand;

        public double Round(double number, int precision = 0)
        {
            var precisionFactor = Math.Pow(10, precision);
            return Math.Round(number * precisionFactor) / precisionFactor;
        }

        public double Substract(double minuend, double subtrahend) => minuend - subtrahend;

        public double Sum<T>(IEnumerable<T> enumerable) => typeof(T).IsNumeric() ? enumerable.Cast<double>().Sum() : double.NaN;

        public double SumBy<T>(IEnumerable<T> enumerable, Func<T, double> iteratee) => enumerable.Sum(iteratee);

        public double SumBy<T>(IEnumerable<T> enumerable, string iteratee)
        {
            Func<T, double> func = item => (double)typeof(T).GetTypeInfo().GetProperty(iteratee).GetValue(item);
            return SumBy(enumerable, func);
        }
    }
}