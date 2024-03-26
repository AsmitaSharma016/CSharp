using System;

class Circle
{
    public double Radius { get; }
    private const double Pi = Math.PI;

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("The Radius should be greater than zero!");
        }
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Pi * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Pi * Radius;
    }

    public bool IsPointInside(double x, double y)
    {
        // This checks if the distance from the center of the circle is less than or equal to the radius to the point
        return Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(Radius, 2);
    }
}

class Program
{
    static Circle[] CreateCircles(int numberOfCircles)
    {
        Circle[] circles = new Circle[numberOfCircles];
        for (int i = 0; i < numberOfCircles; i++)
        {
            double radius;
            do
            {
                Console.Write($"Enter the radius for circle {i + 1}: ");
            } while (!double.TryParse(Console.ReadLine(), out radius) || radius <= 0);

            circles[i] = new Circle(radius);
        }
        return circles;
    }

    static void PrintCircleInfo(Circle circle)
    {
        Console.WriteLine($"The circle with radius {circle.Radius} :");
        Console.WriteLine($"Area : {circle.CalculateArea()}");
        Console.WriteLine($"Perimeter : {circle.CalculatePerimeter()}");
    }

    static (double, double) GetPoint()
    {
        double x, y;
        do
        {
            Console.Write("Enter x-coordinate : ");
        } while (!double.TryParse(Console.ReadLine(), out x));
        do
        {
            Console.Write("Enter y-coordinate : ");
        } while (!double.TryParse(Console.ReadLine(), out y));

        return (x, y);
    }

    static void Main(string[] args)
    {
        int numberOfCircles;
        do
        {
            Console.Write("Enter the number of circles to create: ");
        } while (!int.TryParse(Console.ReadLine(), out numberOfCircles) || numberOfCircles <= 0);

        Circle[] circles = CreateCircles(numberOfCircles);

        Console.WriteLine("\nThe Circle Information:");
        foreach (var circle in circles)
        {
            PrintCircleInfo(circle);
        }

        var point = GetPoint();

        foreach (var circle in circles)
        {
            bool isInside = circle.IsPointInside(point.Item1, point.Item2);
            Console.WriteLine($"<< The Point ({point.Item1}, {point.Item2}) {(isInside ? "is" : "is not")} inside of circle with radius {circle.Radius}>>");
        }
    }
}