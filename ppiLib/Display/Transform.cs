using ppiLib.Types;
using ppiLib.Types._Attributes;

namespace ppiLib.Display;

public class Transform
{
    [Normalized]
    public V LocalPosition { get; set; }
    
    [Normalized]
    public V LocalScale { get; set; }
    
    [Normalized]
    public V LocalRotation { get; set; }
    
    [Absolute]
    public V Position { get; private set; }
    
    [Absolute]
    public V Scale { get; private set; }
    
    [Absolute]
    public V Rotation { get; private set; }
    
}