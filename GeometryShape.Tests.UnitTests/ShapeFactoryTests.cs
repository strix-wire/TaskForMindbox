using GeometryShape.Application.Exceptions;
using GeometryShape.Application.Factories;
using GeometryShape.Application.Interfaces;
using GeometryShape.Application.ShapeConfigurations;
using GeometryShape.Application.Shapes;
using Xunit;

namespace GeometryShape.Tests.UnitTests;

public class ShapeFactoryTests
{
    [Fact]
    public void CreateShape_ShouldThrowArgumentNullException_WhenConfigurationIsNull()
    {
        // Arrange
        IShapeConfiguration configuration = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => ShapeFactory.CreateShape(configuration));
    }

    [Fact]
    public void CreateShape_ShouldReturnCircleInstance_WhenConfigurationIsCircle()
    {
        // Arrange
        var configuration = new CircleConfiguration { Radius = 5.0 };

        // Act
        var shape = ShapeFactory.CreateShape(configuration);

        // Assert
        Assert.NotNull(shape);
        Assert.IsType<Circle>(shape);
    }

    [Fact]
    public void CreateShape_ShouldReturnTriangleInstance_WhenConfigurationIsTriangle()
    {
        // Arrange
        var configuration = new TriangleConfiguration { SideA = 3.0, SideB = 4.0, SideC = 5.0 };

        // Act
        var shape = ShapeFactory.CreateShape(configuration);

        // Assert
        Assert.NotNull(shape);
        Assert.IsType<Triangle>(shape);
    }

    [Fact]
    public void CreateShape_ShouldThrowArgumentException_WhenConfigurationIsUnsupported()
    {
        // Arrange
        var configuration = new UnsupportedShapeConfiguration();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(configuration));
    }

    [Fact]
    public void CreateShape_ShouldThrowArgumentException_WhenCircleConfigurationHasNegativeRadius()
    {
        // Arrange
        var configuration = new CircleConfiguration { Radius = -5.0 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => ShapeFactory.CreateShape(configuration));
    }

    [Fact]
    public void CreateShape_ShouldThrowArgumentException_WhenTriangleConfigurationHasInvalidSideLengths()
    {
        // Arrange
        var configuration = new TriangleConfiguration { SideA = 1.0, SideB = 2.0, SideC = 10.0 };

        // Act & Assert
        Assert.Throws<InvalidTriangleException>(() => ShapeFactory.CreateShape(configuration));
    }

    [Fact]
    public void CreateShape_ShouldReturnTriangleInstance_WhenConfigurationIsTriangleWithValidSideLengths()
    {
        // Arrange
        var configuration = new TriangleConfiguration { SideA = 3.0, SideB = 4.0, SideC = 5.0 };

        // Act
        var shape = ShapeFactory.CreateShape(configuration);

        // Assert
        Assert.NotNull(shape);
        Assert.IsType<Triangle>(shape);
    }

    [Theory]
    [InlineData(5.0, 78.53981633974483)]
    public void CreateShape_ShouldCalculateCorrectAreaForCircle(double radius, double expectedArea)
    {
        // Arrange
        var configuration = new CircleConfiguration { Radius = radius };

        // Act
        var shape = ShapeFactory.CreateShape(configuration);
        var calculatedArea = shape.GetArea();

        // Assert
        Assert.Equal(expectedArea, calculatedArea, 10); // Allowing a small delta of 10 decimal places
    }

    [Theory]
    [InlineData(3.0, 4.0, 5.0, 6.0)]
    public void CreateShape_ShouldCalculateCorrectAreaForTriangle(double sideA, double sideB, double sideC, double expectedArea)
    {
        // Arrange
        var configuration = new TriangleConfiguration { SideA = sideA, SideB = sideB, SideC = sideC };

        // Act
        var shape = ShapeFactory.CreateShape(configuration);
        var calculatedArea = shape.GetArea();

        // Assert
        Assert.Equal(expectedArea, calculatedArea, 10); // Allowing a small delta of 10 decimal places
    }
}

public class UnsupportedShapeConfiguration : IShapeConfiguration
{
    public ShapeType ShapeType => ShapeType.Unknown;
}
