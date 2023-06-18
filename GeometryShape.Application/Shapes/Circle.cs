using GeometryShape.Application.Interfaces;

namespace GeometryShape.Application.Shapes;

public class Circle : IShape
{
	private readonly double _radius;

	public Circle(double radius)
	{
		ValidateCircleRadius(radius);
		_radius = radius;
	}

	public double GetArea()
		=> Math.PI * Math.Pow(_radius, 2);

    private static void ValidateCircleRadius(double radius)
	{
        if (radius <= 0)
            throw new ArgumentOutOfRangeException(nameof(radius),
                "Triangle sides must be greater than zero.");
    }
}