using Packt.Shared; // To use Viper.
using System.IO.Compression; // To use BrotliStream, GZipStream.
using System.Xml; // To use XmlWriter, XmlReader.

partial class Program
{
    // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.compressionlevel?view=net-8.0 

    private static void Compress(string algorithm = "gzip")
    {
        Stream compressor;
        Stream decompressor;

        SectionTitle("Compressing streams");

        // Define a file path using the algorithm as file extension.
        string filePath = Combine(CurrentDirectory, $"streams.{algorithm}");
        FileStream file = File.Create(filePath);
        
        if (algorithm == "gzip")
            compressor = new GZipStream(file, CompressionMode.Compress);
        else
            compressor = new BrotliStream(file, CompressionMode.Compress);

        using(compressor)
        {
            using (XmlWriter xml = XmlWriter.Create(compressor))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");
        
                foreach (string item in Viper.Callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }
            }
        }  // Also closes the underlying stream.

        OutputFileInfo(filePath);

        // Read the compressed file.
        WriteLine("Reading the compressed XML file:");

        file = File.Open(filePath, FileMode.Open);

        if (algorithm == "gzip")
            decompressor = new GZipStream(file, CompressionMode.Decompress);
        else
            decompressor = new BrotliStream(file, CompressionMode.Decompress);

        using (decompressor)

        using(XmlReader reader = XmlReader.Create(decompressor))

        while(reader.Read())
        {
            // Check if we are on an element node named callsign.
            if ((reader.NodeType == XmlNodeType.Element)
                && (reader.Name == "callsign"))
            {
                reader.Read(); // Move to the text inside element.
                WriteLine($"{reader.Value}"); // Read its value.
            }

            // Alternative syntax with property pattern matching:
            // if (reader is { NodeType: XmlNodeType.Element, Name: "callsign" })
        }
    }
}