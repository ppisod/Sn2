#nullable enable
using System.Collections.Generic;
using ppiLib.Display;

namespace ppiLib.Node;

/// <summary>
/// A Node - a graphical object that can be added to the scene graph.
/// Nodes can be transformed. But these transformations can be ignored.
/// The Node parent-child system will take care of eeeverything.
/// </summary>
public class Node ( NConfig config ) {
    
    public required Transform T { get; set; } = config.Transform;
    public Node? Parent { get; private set; } = config.Parent;
    public List <Node> Children { get; private set; } = [];

    public virtual void AddChild ( Node child ) {
        
    }

    public virtual void RemoveChild ( Node child ) {
        
    }

    public virtual void Draw ( ) {
        
    }

    public virtual void Update ( ) {
        
    }

    public virtual void Destroy ( ) {
        
    }
}