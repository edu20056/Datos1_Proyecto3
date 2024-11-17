using AirWar.GameObjects;

public class AirBaseGraph
{
    public List<AirBaseNode> Nodes { get; private set; }

    public AirBaseGraph()
    {
        Nodes = new List<AirBaseNode>();
    }

    // Agregar un nodo al grafo
    public AirBaseNode AddNode(AirBase airBase)
    {
        var newNode = new AirBaseNode(airBase);
        Nodes.Add(newNode);
        return newNode;
    }

    public void AddEdge(AirBaseNode from, AirBaseNode to)
    {
        from.AddConnection(to);
    }
}
