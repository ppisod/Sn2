using ppiLib.Types;

namespace ppiLib.Display;

public class Arrangement
{
    public Q<V> Position { get; set; } = new(V.One, V.Zero, V.One);
    public Q<V> Scale { get; set; } = new(V.One, V.Zero, V.One);
    public float Rotation { get; set; } = 0f;
    public Q<V> Padding { get; set; } = new(V.Zero, V.Zero, V.One);
    public Q<V> Margin { get; set; } = new(V.Zero, V.Zero, V.One);
} 