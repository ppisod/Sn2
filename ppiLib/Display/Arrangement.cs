using ppiLib.Types;

namespace ppiLib.Display;

public class Arrangement
{
    public Q<V> Position { get; private set; }
    public Q<V> Scale { get; private set; }
    public Q<V> Rotation { get; private set; }
    public Q<V> Padding { get; private set; }
}