List<Shape> shapes = new List<Shape>();

shapes.Add(new Square("red", 4));
shapes.Add(new Rectangle("blue", 5, 3));
shapes.Add(new Circle("green", 2));

foreach (Shape shape in shapes)
{
    Console.WriteLine($"{shape.GetColor()} shape: area {shape.GetArea()}");
}