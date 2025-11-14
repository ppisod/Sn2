using ppiLib.Types;

namespace ppiLib.Display;

public class Arrangement ( Q <V> pos, Q <V> scale, float rot, Q <V> padding, Q <V> margin ) {
    public Arrangement ( ) 
        : this ( Q <V>.Identity, 
            Q <V>.One, 
            0f, 
            Q <V>.Zero, 
            Q <V>.Zero ) { }

    public Q<V> Position { get; set; } = pos;
    public Q<V> Scale { get; set; } = scale;
    public float Rotation { get; set; } = rot;
    public Q<V> Padding { get; set; } = padding;
    public Q<V> Margin { get; set; } = margin;
} 