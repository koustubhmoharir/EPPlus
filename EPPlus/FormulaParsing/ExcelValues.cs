﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OfficeOpenXml
{
    /// <summary>
    /// Represents the errortypes in excel
    /// </summary>
    public enum eErrorType
    {
        /// <summary>
        /// Division by zero
        /// </summary>
        Div0,
        /// <summary>
        /// Not applicable
        /// </summary>
        NA,
        /// <summary>
        /// Name error
        /// </summary>
        Name,
        /// <summary>
        /// Null error
        /// </summary>
        Null,
        /// <summary>
        /// Num error
        /// </summary>
        Num,
        /// <summary>
        /// Reference error
        /// </summary>
        Ref,
        /// <summary>
        /// Value error
        /// </summary>
        Value,
        /// <summary>
        /// Getting Data error
        /// </summary>
        GettingData
    }

    /// <summary>
    /// Represents an Excel error.
    /// </summary>
    /// <seealso cref="eErrorType"/>
    public class ExcelErrorValue
    {
        /// <summary>
        /// Handles the convertion between <see cref="eErrorType"/> and the string values
        /// used by Excel.
        /// </summary>
        public static class Values
        {
            public const string Div0 = "#DIV/0!";
            public const string NA = "#N/A";
            public const string Name = "#NAME?";
            public const string Null = "#NULL!";
            public const string Num = "#NUM!";
            public const string Ref = "#REF!";
            public const string Value = "#VALUE!";
            public const string GettingData = "#GETTING_DATA";


            private static Dictionary<string, eErrorType> _values = new Dictionary<string, eErrorType>()
                {
                    {Div0, eErrorType.Div0},
                    {NA, eErrorType.NA},
                    {Name, eErrorType.Name},
                    {Null, eErrorType.Null},
                    {Num, eErrorType.Num},
                    {Ref, eErrorType.Ref},
                    {Value, eErrorType.Value},
                    {GettingData, eErrorType.GettingData}
                };

            /// <summary>
            /// Returns true if the supplied <paramref name="candidate"/> is an excel error.
            /// </summary>
            /// <param name="candidate"></param>
            /// <returns></returns>
            public static bool IsErrorValue(object candidate)
            {
                if(candidate == null || !(candidate is ExcelErrorValue)) return false;
                var candidateString = candidate.ToString();
                return (!string.IsNullOrEmpty(candidateString) && _values.ContainsKey(candidateString));
            }

            /// <summary>
            /// Returns true if the supplied <paramref name="candidate"/> is an excel error.
            /// </summary>
            /// <param name="candidate"></param>
            /// <returns></returns>
            public static bool StringIsErrorValue(string candidate)
            {
                return (!string.IsNullOrEmpty(candidate) && _values.ContainsKey(candidate));
            }

            /// <summary>
            /// Converts a string to an <see cref="eErrorType"/>
            /// </summary>
            /// <param name="val"></param>
            /// <returns></returns>
            /// <exception cref="ArgumentException">Thrown if the supplied value is not an Excel error</exception>
            public static eErrorType ToErrorType(string val)
            {
                if (string.IsNullOrEmpty(val) || !_values.ContainsKey(val))
                {
                    throw new ArgumentException("Invalid error code " + (val ?? "<empty>"));
                }
                return _values[val];
            }
        }

        public static ExcelErrorValue Create(eErrorType errorType)
        {
            switch (errorType)
            {
                case eErrorType.Div0:
                    return Div0;
                case eErrorType.NA:
                    return NA;
                case eErrorType.Name:
                    return Name;
                case eErrorType.Null:
                    return Null;
                case eErrorType.Num:
                    return Num;
                case eErrorType.Ref:
                    return Ref;
                case eErrorType.Value:
                    return Value;
                case eErrorType.GettingData:
                    return GettingData;
            }
            return new ExcelErrorValue(errorType);
        }

        public static readonly ExcelErrorValue Null = new ExcelErrorValue(eErrorType.Null);
        public static readonly ExcelErrorValue Div0 = new ExcelErrorValue(eErrorType.Div0);
        public static readonly ExcelErrorValue Value = new ExcelErrorValue(eErrorType.Value);
        public static readonly ExcelErrorValue Ref = new ExcelErrorValue(eErrorType.Ref);
        public static readonly ExcelErrorValue Name = new ExcelErrorValue(eErrorType.Name);
        public static readonly ExcelErrorValue Num = new ExcelErrorValue(eErrorType.Num);
        public static readonly ExcelErrorValue NA = new ExcelErrorValue(eErrorType.NA);
        public static readonly ExcelErrorValue GettingData = new ExcelErrorValue(eErrorType.GettingData);

        public static ExcelErrorValue Parse(string val)
        {
            if (Values.StringIsErrorValue(val))
            {
                return Create(Values.ToErrorType(val));
            }
            if(string.IsNullOrEmpty(val)) throw new ArgumentNullException("val");
            throw new ArgumentException("Not a valid error value: " + val);
        }

        private ExcelErrorValue(eErrorType type)
        {
            Type=type; 
        }

        /// <summary>
        /// The error type
        /// </summary>
        public eErrorType Type { get; private set; }

        /// <summary>
        /// Returns the string representation of the error type
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch(Type)
            {
                case eErrorType.Div0:
                    return Values.Div0;
                case eErrorType.NA:
                    return Values.NA;
                case eErrorType.Name:
                    return Values.Name;
                case eErrorType.Null:
                    return Values.Null;
                case eErrorType.Num:
                    return Values.Num;
                case eErrorType.Ref:
                    return Values.Ref;
                case eErrorType.Value:
                    return Values.Value;
                case eErrorType.GettingData:
                    return Values.GettingData;
                default:
                    throw(new ArgumentException("Invalid errortype"));
            }
        }
        public static ExcelErrorValue operator +(object v1, ExcelErrorValue v2)
        {
            return v2;
        }
        public static ExcelErrorValue operator +(ExcelErrorValue v1, ExcelErrorValue v2)
        {
            return v1;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ExcelErrorValue)) return false;
            return ((ExcelErrorValue) obj).ToString() == this.ToString();
        }
    }
}
