using System.Threading.Tasks.Sources;

namespace PracticeOOP;

/// <summary>
/// Triangle Rectangle
/// </summary>
public class Triangle
{
    /// <summary>
    /// Side1 in the rectangle angle
    /// </summary>
    public double Side1 { get; set; } = 0;

    /// <summary>
    /// Side2 in the Rectangle angle
    /// </summary>
    public double Side2 { get; set; } = 0;

    /// <summary>
    /// Calculate the Hipotenuse using the square root of  the addition 
    /// of side1 elevate to squere and the side2 elevate to square
    /// </summary>
    public double Hipotenuse
    {
        get
        {
            return Math.Sqrt(Math.Pow(Side1, 2) + Math.Pow(Side2, 2));
        }
    }

    /// <summary>
    /// DEfault Constructor
    /// </summary>
    public Triangle()
    {
        Side1 = 0;
        Side2 = 0;
    }

    /// <summary>
    /// Constructor with Parameters
    /// </summary>
    /// <param name="side1">Side 1 in the rectangle Angle</param>
    /// <param name="side2">Side 2 in the rectangle Angle</param>
    public Triangle(double side1, double side2)
    {
        Side1 = side1;
        Side2 = side2;
    }

    /// <summary>
    /// Calculate the Perimetr using the values for Side1, Side2 and the Hipotenuse
    /// </summary>
    /// <returns></returns>
    public double GetPerimeter()
    {
        return Side1 + Side2 + Hipotenuse;
    }
}