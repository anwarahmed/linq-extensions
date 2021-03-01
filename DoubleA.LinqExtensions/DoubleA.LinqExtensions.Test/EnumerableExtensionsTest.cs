using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoubleA.LinqExtensions.Test
{
    [TestClass]
    public class EnumerableExtensionsTest
    {
        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Class_NoNulls()
        {
            // Arrange
            var enumerable = new List<string>
            {
                "a",
                "b",
                "c"
            };

            var expected = new[]
            {
                "a",
                "b",
                "c"
            };

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Class_SomeNulls()
        {
            // Arrange
            var enumerable = new List<string>
            {
                "a",
                "b",
                null,
                "d",
                null,
                "e"
            };

            var expected = new[]
            {
                "a",
                "b",
                "d",
                "e"
            };

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Class_AllNulls()
        {
            // Arrange
            var enumerable = new List<string>
            {
                null,
                null,
                null
            };

            var expected = Enumerable.Empty<string>();

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Class_EmptyList()
        {
            // Arrange
            var enumerable = new List<string>();

            var expected = Enumerable.Empty<string>();

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Class_NullList()
        {
            // Arrange
            List<string> enumerable = null;

            var expected = Enumerable.Empty<string>();

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Struct_NoNulls()
        {
            // Arrange
            var enumerable = new List<int?>
            {
                1,
                2,
                3
            };

            var expected = new[]
            {
                1,
                2,
                3
            };

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Struct_SomeNulls()
        {
            // Arrange
            var enumerable = new List<int?>
            {
                1,
                2,
                null,
                4,
                null,
                6
            };

            var expected = new[]
            {
                1,
                2,
                4,
                6
            };

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Struct_AllNulls()
        {
            // Arrange
            var enumerable = new List<int?>
            {
                null,
                null,
                null
            };

            var expected = Enumerable.Empty<int>();

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Struct_EmptyList()
        {
            // Arrange
            var enumerable = new List<int?>();

            var expected = Enumerable.Empty<int>();

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void EnumerableExtensions_WithoutNulls_Struct_NullList()
        {
            // Arrange
            List<int?> enumerable = null;

            var expected = Enumerable.Empty<int>();

            // Act
            var actual = enumerable.WithoutNulls();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
