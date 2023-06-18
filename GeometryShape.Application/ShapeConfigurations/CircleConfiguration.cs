using GeometryShape.Application.Interfaces;
using GeometryShape.Application.Shapes;

namespace GeometryShape.Application.ShapeConfigurations;

public class CircleConfiguration : IShapeConfiguration
{
    public double Radius { get; set; }
    public ShapeType ShapeType { get => ShapeType.Circle; }
}

