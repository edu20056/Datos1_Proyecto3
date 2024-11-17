using AirWar.GameObjects;

public class AirBaseNode
{
    public AirBase Base { get; private set; }
    public List<AirBaseNode> Connections { get; private set; }

    public AirBaseNode(AirBase airBase)
    {
        Base = airBase;
        Connections = new List<AirBaseNode>();
    }

    public void AddConnection(AirBaseNode otherNode)
    {
        if (!Connections.Contains(otherNode))
        {
            Connections.Add(otherNode);
        }
    }
}
