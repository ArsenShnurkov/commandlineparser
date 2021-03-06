﻿using System;
using System.Collections.Generic;
using Xunit;

namespace MGR.CommandLineParser.UnitTests.Extensions
{
    public partial class TypeExtensionsTests
    {
        public class IsDictionaryType
        {
            [Fact]
            public void ListIntTest()
            {
                // Arrange
                var testedType = typeof (List<int>);
                var expected = false;

                // Act
                var actual = testedType.IsDictionaryType();

                // Assert
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void ICollectionIntTest()
            {
                // Arrange
                var testedType = typeof (ICollection<int>);
                var expected = false;

                // Act
                var actual = testedType.IsDictionaryType();

                // Assert
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TupleInt()
            {
                // Arrange
                var testedType = typeof (Tuple<int>);
                var expected = false;

                // Act
                var actual = testedType.IsDictionaryType();

                // Assert
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void DictionaryStringInt()
            {
                // Arrange
                var testedType = typeof (Dictionary<string, int>);
                var expected = true;

                // Act
                var actual = testedType.IsDictionaryType();

                // Assert
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void IDictionaryStringInt()
            {
                // Arrange
                var testedType = typeof (IDictionary<string, int>);
                var expected = true;

                // Act
                var actual = testedType.IsDictionaryType();

                // Assert
                Assert.Equal(expected, actual);
            }

            [Fact]
            public void NullTypeException()
            {
                // Arrange
                Type testedType = null;
                var expectedExceptionMessage = SourceParameterName;

                // Act
                var actualException = Assert.Throws<ArgumentNullException>(() => testedType.IsDictionaryType());

                // Assert
                Assert.Equal(expectedExceptionMessage, actualException.ParamName);
            }
        }
    }
}