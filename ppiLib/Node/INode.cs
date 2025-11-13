namespace ppiLib.Node;

public interface INode
{
    public void AddChild (INode child);
    public void RemoveChild (INode child);
    public void Draw ();
    public void Update ();
    public void Destroy ();
}