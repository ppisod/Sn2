using ppiLib.Types;
using ppiLib.Types._Attributes;

namespace ppiLib.Display;

public class Transform
{
    public Arrangement LocalArrangement { get; set; }
    public Arrangement WorldArrangement { get; private set; }
}