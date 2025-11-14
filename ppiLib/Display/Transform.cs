using ppiLib.Types;
using ppiLib.Types._Attributes;

namespace ppiLib.Display;

/// <summary>
/// Stores all positional/transform data for a Node. Or just any graphical things.
/// </summary>
public class Transform
{
    public Transform ( ) {
        LocalArrangement = new Arrangement ();
        
        var screenSize = new V 
            ( Core.DeviceManager.PreferredBackBufferWidth, Core.DeviceManager.PreferredBackBufferHeight );
        
        // this is the default world arrangement, which is just the size of the screen
        // only used when the node is not attached to a parent.
        
        // Also, do NOT initialize nodes in initiate; it's better to initialize in Update() and reinitialize when
        // the screen changes size.
        
        WorldArrangement = new Arrangement (
            new Q<V> (V.Zero, V.Zero, screenSize),
            new Q<V> (V.One, V.Zero, screenSize),
            0f,
            new Q<V> (V.Zero, V.Zero, screenSize),
            new Q<V> (V.Zero, V.Zero, screenSize)
        );
    }
    public Arrangement LocalArrangement { get; set; }
    public Arrangement WorldArrangement { get; private set; }
}