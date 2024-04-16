using Packt.Shared;

string path = Combine(CurrentDirectory, "shapes.xml");

// Create a list of Shapes to serialize.
List<Shape> listOfShapes = new()
{
    new Circle { Colour = "Red", Radius = 2.5 },
    new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
    new Circle { Colour = "Green", Radius = 8.0 },
    new Circle { Colour = "Purple", Radius = 12.3 },
    new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
};

// Serialize.
Serialize(path, listOfShapes);

// Deserialize.
Deserialize(path, listOfShapes);
