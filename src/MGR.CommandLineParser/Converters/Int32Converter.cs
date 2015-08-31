﻿using System;
using System.Globalization;

namespace MGR.CommandLineParser.Converters
{
    /// <summary>
    /// Converter for the type <see cref="int"/>.
    /// </summary>
    public sealed class Int32Converter : IConverter
    {
        /// <summary>
        /// The target type of the converter (<see cref="int"/>)..
        /// </summary>
        public Type TargetType => typeof (int);

        /// <summary>
        /// Convert the <paramref name="value"/> to an instance of <see cref="Int32"/>.
        /// </summary>
        /// <param name="value">The original value provided by the user.</param>
        /// <param name="concreteTargetType">Not used.</param>
        /// <returns>The <see cref="Int32"/> converted from the value.</returns>
        /// <exception cref="CommandLineParserException">Thrown if the <paramref name="value"/> is not valid.</exception>
        public object Convert(string value, Type concreteTargetType)
        {
            try
            {
                return int.Parse(value, CultureInfo.CurrentUICulture);
            }
            catch (FormatException exception)
            {
                throw new CommandLineParserException(Constants.ExceptionMessages.FormatConverterUnableConvert(value, TargetType), exception);
            }
        }
    }
}