//Box Opgave
global using OOPH1.Codes;

Box a = new Box(5.0, 5.0, 5.0);
Console.WriteLine($"Box a : {a.ToString()}");

Console.WriteLine();

Box b = new Box(4.0, 4.0, 4.0);
Console.WriteLine($"Box b : {b.ToString()}");

Console.WriteLine();

Box c = a + b;
Console.WriteLine($"Box c : {c.ToString()}");

List<Box> boxes = new()
{
    a,
    b,
    c
};

boxes.Sort();
boxes.Reverse();

foreach (Box item in boxes)
    Console.WriteLine($"Volume : {item.Volume}");

Console.ReadLine();