using GeometryShape.Application.Interfaces;
using GeometryShape.Application.ShapeConfigurations;
using GeometryShape.Application.Shapes;

namespace GeometryShape.Application.Factories;

public class ShapeFactory
{
    public static IShape CreateShape(IShapeConfiguration configuration)
    {
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        switch (configuration.ShapeType)
        {
            case ShapeType.Circle:
                if (configuration is not CircleConfiguration circleConfiguration)
                    throw new ArgumentException($"Invalid configuration type for Circle: {configuration.GetType()}");

                return new Circle(circleConfiguration.Radius);

            case ShapeType.Triangle:
                if (configuration is not TriangleConfiguration triangleConfiguration)
                    throw new ArgumentException($"Invalid configuration type for Triangle: {configuration.GetType()}");

                return new Triangle(triangleConfiguration.SideA, triangleConfiguration.SideB, triangleConfiguration.SideC);

            default:
                throw new ArgumentException($"Unsupported configuration type: {configuration.GetType()}");
        }
    }
}

