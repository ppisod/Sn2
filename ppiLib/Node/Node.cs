#nullable enable
using ppiLib.Display;

namespace ppiLib.Node;

/// <summary>
/// A Node - a graphical object that can be added to the scene graph.
/// Nodes can be transformed. But these transformations can be ignored.
/// The Node system will take care of the transformations.
/// The Node loves you.
/// </summary>
public abstract class Node {

    public Node ( NConfig config ) {
        
    }
    
    public required Transform T { get; set; }
    public Node? Parent { get; private set; }
    
    public abstract void AddChild ( Node child );
    public abstract void RemoveChild ( Node child );
    public abstract void Draw ( );
    public abstract void Update ( );
    public abstract void Destroy ( );
}