using System.Xml;

public static class XmlParser
{
    public static Order ParseOrder(string xml)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);

        XmlNode shipToNode = doc.SelectSingleNode("//shipTo");
        XmlNodeList itemNodes = doc.SelectNodes("//item");

        Order order = new Order();

        if (shipToNode != null)
        {
            order.ShipTo = new ShipTo
            {
                Name = GetValue(shipToNode, "name"),
                Street = GetValue(shipToNode, "street"),
                Address = GetValue(shipToNode, "address"),
                Country = GetValue(shipToNode, "country")
            };
        }

        if (itemNodes != null)
        {
            order.Items = new List<Item>();

            foreach (XmlNode itemNode in itemNodes)
            {
                Item item = new Item
                {
                    Title = GetValue(itemNode, "title"),
                    Quantity = int.Parse(GetValue(itemNode, "quantity")),
                    Price = decimal.Parse(GetValue(itemNode, "price"))
                };

                order.Items.Add(item);
            }
        }

        return order;
    }

    private static string GetValue(XmlNode parentNode, string nodeName)
    {
        XmlNode node = parentNode.SelectSingleNode(nodeName);
        return node?.InnerText?.Trim();
    }
}

public class Order
{
    public ShipTo ShipTo { get; set; }
    public List<Item> Items { get; set; }
}

public class ShipTo
{
    public string Name { get; set; }
    public string Street { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
}

public class Item
{
    public string Title { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        string xml = "<?xml version=\"1.0\" ?><shipOrder><shipTo><name>Tove Svendson</name><street>Ragnhildvei 2</street><address>4000 Stavanger</address><country>Norway</country></shipTo><items><item><title>Empire Burlesque</title><quantity>1</quantity><price>10.90</price></item><item><title>Hide your heart</title><quantity>1</quantity><price>9.90</price></item></items></shipOrder>";

        Order order = XmlParser.ParseOrder(xml);

        Console.WriteLine("Ship To:");
        Console.WriteLine($"Name: {order.ShipTo.Name}");
        Console.WriteLine($"Street: {order.ShipTo.Street}");
        Console.WriteLine($"Address: {order.ShipTo.Address}");
        Console.WriteLine($"Country: {order.ShipTo.Country}");

        Console.WriteLine("Items:");

        foreach (Item item in order.Items)
        {
            Console.WriteLine($"Title: {item.Title}");
            Console.WriteLine($"Quantity: {item.Quantity}");
            Console.WriteLine($"Price: {item.Price}");
            Console.WriteLine();
        }
    }
}
