using GeometryShape.Application.Shapes;

namespace GeometryShape.Application.Interfaces;

public interface IShapeConfiguration
{
    ShapeType ShapeType { get; }
}

