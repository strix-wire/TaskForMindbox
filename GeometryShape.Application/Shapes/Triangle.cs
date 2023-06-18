using System;
using GeometryShape.Application.Exceptions;
using GeometryShape.Application.Interfaces;

namespace GeometryShape.Application.Shapes;

public class Triangle : IShape
{
	private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        ValidateTriangleSides(sideA, sideB, sideC);

        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public double GetArea()
    {
        double semiPerimeter = (_sideA + _sideB + _sideC) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA)
            * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
    }

    private static void ValidateTriangleSides(double sideA, double sideB, double sideC)
    {
        double[] sides = { sideA, sideB, sideC };

        for (int i = 0; i < sides.Length; i++)      
            if (sides[i] <= 0)
                throw new ArgumentOutOfRangeException($"Side {i + 1}",
                    "Triangle sides must be greater than zero.");        

        if (!IsCanExist(sideA, sideB, sideC))
            throw new InvalidTriangleException("Invalid triangle side.");
    }

    /// <summary>
    /// Check is can exist triangle
    /// </summary>
    /// <returns>false - not exist
    /// true - exist </returns>
    private static bool IsCanExist(double sideA, double sideB, double sideC)
    {
        return (sideA + sideB > sideC)
            && (sideB + sideC > sideA) && (sideC + sideA > sideB);
    }
}