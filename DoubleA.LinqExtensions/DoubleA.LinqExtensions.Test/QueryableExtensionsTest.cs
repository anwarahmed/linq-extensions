using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoubleA.LinqExtensions.Test
{
    [TestClass]
    public class QueryableExtensionsTest
    {
        [TestMethod]
        public void QueryableExtensions_Filter_NoNullFilters()
        {
            // Arrange
            var query = new[]
            {
                "windows",
                "linux",
                "macos",
                "unix",
                "android",
                "ios"
            }.AsQueryable();

            var expected = new[]
            {
                "windows",
                "android",
                "ios"
            }.AsQueryable();

            // Act
            var actual = query.Filter(
                s => s.Contains('i'),
                s => s.Contains('o'));

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void QueryableExtensions_Filter_SomeNullFilters()
        {
            // Arrange
            var query = new[]
            {
                "windows",
                "linux",
                "macos",
                "unix",
                "android",
                "ios"
            }.AsQueryable();

            var expected = new[]
            {
                "windows",
                "android",
                "ios"
            }.AsQueryable();

            // Act
            var actual = query.Filter(
                s => s.Contains('i'),
                null,
                s => s.Contains('o'),
                null);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void QueryableExtensions_Filter_SingleNullFilter()
        {
            // Arrange
            var query = new[]
            {
                "windows",
                "linux",
                "macos",
                "unix",
                "android",
                "ios"
            }.AsQueryable();

            var expected = new[]
            {
                "windows",
                "linux",
                "macos",
                "unix",
                "android",
                "ios"
            }.AsQueryable();

            // Act
            var actual = query.Filter(null);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void QueryableExtensions_Filter_MultipleNullFilters()
        {
            // Arrange
            var query = new[]
            {
                "windows",
                "linux",
                "macos",
                "unix",
                "android",
                "ios"
            }.AsQueryable();

            var expected = new[]
            {
                "windows",
                "linux",
                "macos",
                "unix",
                "android",
                "ios"
            }.AsQueryable();

            // Act
            var actual = query.Filter(
                null,
                null,
                null);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void QueryableExtensions_Filter_NullQuery()
        {
            // Arrange
            IQueryable<string> query = null;

            try
            {
                // Act
                var actual = query.Filter(s => s.Length == 1);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                // Assert
                ex.ParamName.Should().Be(nameof(query));
            }
        }

        [TestMethod]
        public void QueryableExtensions_Filter_NullQuery_NullFilter()
        {
            // Arrange
            IQueryable<string> query = null;

            try
            {
                // Act
                var actual = query.Filter(null);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                // Assert
                ex.ParamName.Should().Be(nameof(query));
            }
        }
    }
}
