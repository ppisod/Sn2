using ppiLib.Display;

namespace ppiLib.Node;

public abstract class Node
{
    
    public Transform T { get; private set; }
    
    public abstract void AddChild ( Node child );
    public abstract void RemoveChild ( Node child );
    public abstract void Draw ( );
    public abstract void Update ( );
    public abstract void Destroy ( );
}