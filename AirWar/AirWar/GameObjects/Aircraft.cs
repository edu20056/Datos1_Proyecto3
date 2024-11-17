using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

public class Aircraft
{
    public AirBaseNode CurrentNode { get; private set; }
    public AirBaseNode TargetNode { get; private set; }
    public Rectangle Shape { get; private set; }
    private double Speed;

    public Aircraft(AirBaseNode startNode, Canvas canvas, double speed = 2.0)
    {
        CurrentNode = startNode;
        Speed = speed;
    
        Shape = new Rectangle
        {
            Width = 30,
            Height = 30,
            Fill = Brushes.Red
        };

        Canvas.SetLeft(Shape, startNode.Base.X);
        Canvas.SetTop(Shape, startNode.Base.Y);
        canvas.Children.Add(Shape);
    }

    public void MoveTo(AirBaseNode targetNode)
    {
        TargetNode = targetNode;
    }

    public void Update()
    {
        if (TargetNode == null) return;

        double currentX = Canvas.GetLeft(Shape);
        double currentY = Canvas.GetTop(Shape);

        double targetX = TargetNode.Base.X;
        double targetY = TargetNode.Base.Y;

        double dx = targetX - currentX;
        double dy = targetY - currentY;
        double distance = Math.Sqrt(dx * dx + dy * dy);

        if (distance < Speed)
        {
            Canvas.SetLeft(Shape, targetX);
            Canvas.SetTop(Shape, targetY);
            CurrentNode = TargetNode;
            TargetNode = null;
            return;
        }

        Canvas.SetLeft(Shape, currentX + Speed * (dx / distance));
        Canvas.SetTop(Shape, currentY + Speed * (dy / distance));
    }

    public Rect GetRect()
    {
        return new Rect(Canvas.GetLeft(Shape), Canvas.GetTop(Shape), Shape.Width, Shape.Height);
    }
}
