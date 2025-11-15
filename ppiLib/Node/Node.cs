#nullable enable
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ppiLib.Display;

namespace ppiLib.Node;

/// <summary>
/// A Node - a graphical object that can be added to the scene graph.
/// Nodes can be transformed. But these transformations can be ignored.
/// </summary>
public class Node ( NConfig config ) : IDisposable {

    public bool Enabled { get; set; } = true;
    
    public required Transform T { get; set; } = config.Transform;
    public Node? Parent { get; private set; } = config.Parent;
    public List <Node> Children { get; private set; } = [];

    /// <summary>
    /// Adds a child to this node.
    /// Re-parents if the child already has a parent.
    /// Custom behavior can be implemented. But please, call base() first. This method is crucial.
    /// </summary>
    /// <param name="child">The child node</param>
    public virtual void AddChild ( Node child ) {
        child.Parent?.RemoveChild ( child );
        child.Parent = this;
        Children.Add ( child );
    }
    
    /// <summary>
    /// TODO: Implement this!
    /// Adds a child to this node, safely.
    /// checks if it's descendants is ourself, and if so, throws an exception.
    /// </summary>
    /// <param name="child">The child node</param>
    public virtual void SafeAddChild ( Node child ) {
        
    }
    
    /// <summary>
    /// Removes a child from this node.
    /// The child becomes an orphan.
    /// If the child has another parent, nothing will happen.
    /// Custom behavior can be implemented. But please, call base() first. This method is crucial.
    /// </summary>
    /// <param name="child">The child node</param>
    protected virtual void RemoveChild ( Node child ) {
        if (child.Parent != this) return;
        child.Parent = null;
        Children.Remove ( child );
    }
    
    /// <summary>
    /// The draw cycle.
    /// </summary>
    public void Draw ( SpriteBatch batch ) {
        if (!Enabled) return;
        foreach (var child in Children) child.Draw (batch);
        OnDraw ( batch );
    }
    
    /// <summary>
    /// Custom drawing behavior here.
    /// Draw all the shapes you want.
    /// </summary>
    protected virtual void OnDraw ( SpriteBatch batch ) {
        
    }

    /// <summary>
    /// The update cycle.
    /// </summary>
    public void Update ( GameTime time ) {
        if (!Enabled) return;
        foreach (var child in Children) child.Update (time);
        OnUpdate ( time );
    }
    
    /// <summary>
    /// Custom update behavior here.
    /// Update according to game logic.
    /// </summary>
    protected virtual void OnUpdate ( GameTime time ) {
        
    }

    /// <summary>
    /// Custom destroy behavior here.
    /// </summary>
    protected virtual void Destroy ( ) {
        
    }

    public void Dispose ( ) {
        Destroy ( );
        Parent?.RemoveChild ( this );
        foreach (var child in Children) RemoveChild ( child );
    }
}