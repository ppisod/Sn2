#nullable enable
using ppiLib.Display;

namespace ppiLib.Node;

/// <summary>
/// A Node system/builder for arguments passed into Node.
/// ALL Node types' constructors take an NConfig, so ALL node types' different properties are accessible.
/// In this file, only the primitive, required members of NConfig live.
/// </summary>
public partial class NConfig {
    
    public string Name { get; private set; } = "Node";
    public Disp Disp { get; private set; } = new Disp ();
    public Node? Parent { get; private set; }
    
    public NConfig ( NConfig From ) {
        Name = From.Name;
        Disp = From.Disp;
    }

    public NConfig ( ) {
        
    }
}