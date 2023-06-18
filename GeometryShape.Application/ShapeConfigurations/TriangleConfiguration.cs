using GeometryShape.Application.Interfaces;
using GeometryShape.Application.Shapes;

namespace GeometryShape.Application.ShapeConfigurations;

public class TriangleConfiguration : IShapeConfiguration
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }
    public ShapeType ShapeType { get => ShapeType.Triangle; }
}