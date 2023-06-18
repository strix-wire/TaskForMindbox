using GeometryShape.Application.Shapes;

namespace GeometryShape.Tests.UnitTests;

public class TriangleTests
{
    [Fact]
    public void IsRightTriangle_ShouldReturnTrue_WhenTriangleIsRight()
    {
        // Arrange
        double sideA = 3.0;
        double sideB = 4.0;
        double sideC = 5.0;
        var triangle = new Triangle(sideA, sideB, sideC);

        // Act
        bool isRightTriangle = triangle.IsRightTriangle();

        // Assert
        Assert.True(isRightTriangle);
    }

    [Fact]
    public void IsRightTriangle_ShouldReturnFalse_WhenTriangleIsNotRight()
    {
        // Arrange
        double sideA = 3.0;
        double sideB = 4.0;
        double sideC = 6.0;
        var triangle = new Triangle(sideA, sideB, sideC);

        // Act
        bool isRightTriangle = triangle.IsRightTriangle();

        // Assert
        Assert.False(isRightTriangle);
    }
}
