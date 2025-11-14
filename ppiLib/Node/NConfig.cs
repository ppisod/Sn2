using ppiLib.Display;

namespace ppiLib.Node;

/// <summary>
/// A Node system/builder for arguments passed into Node
/// </summary>
public class NConfig
{
    public string Name { get; private set; }
    public Transform Transform { get; private set; }
    
    public NConfig ( NConfig From ) {
        
    }

    public NConfig ( ) {
        
    }
}