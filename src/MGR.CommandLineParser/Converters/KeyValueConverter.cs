﻿using System;
using System.Collections.Generic;

namespace MGR.CommandLineParser.Converters
{
    internal sealed class KeyValueConverter : IConverter
    {
        private readonly IConverter _keyConverter;
        private readonly IConverter _valueConverter;

        internal KeyValueConverter(IConverter keyConverter, IConverter valueConverter)
        {
            if (keyConverter == null)
            {
                throw new ArgumentNullException(nameof(keyConverter));
            }
            if (valueConverter == null)
            {
                throw new ArgumentNullException(nameof(valueConverter));
            }
            _keyConverter = keyConverter;
            _valueConverter = valueConverter;
        }

        public Type TargetType => typeof (KeyValuePair<,>).MakeGenericType(_keyConverter.TargetType, _valueConverter.TargetType);

        public object Convert(string value, Type concreteTargetType)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            var eqIndex = value.IndexOf("=", StringComparison.OrdinalIgnoreCase);
            if (eqIndex > -1)
            {
                var propertyKey = _keyConverter.Convert(value.Substring(0, eqIndex), _keyConverter.TargetType);
                var propertyValue = _valueConverter.Convert(value.Substring(eqIndex + 1), _valueConverter.TargetType);
                return Tuple.Create(propertyKey, propertyValue);
            }
            return Tuple.Create(_keyConverter.Convert(value, _keyConverter.TargetType), (object) null);
        }
    }
}