using Microsoft.Xna.Framework.Graphics;
using ppiLib.Types;
using ppiLib.Types._Attributes;

namespace ppiLib.Display;

public class Disp {

    public Disp ( ) {
        Origin = V.Zero;
        Size = new Q <V> ( new V ( 1 ), new V ( 0 ), new V ( 1 ) );
        Padding = new Q <V> ( new V ( 0 ), new V ( 0 ), new V ( 1 ) );
        Position = new Q <V> ( new V ( 0 ), new V ( 0 ), new V ( 1 ) );
    }

    public Disp (
        V origin,
        V normalizedSize,
        V normalizedPadding,
        V normalizedPosition,
        V reference
    ) {
        Origin = origin;
        Size = new Q <V> ( normalizedSize, V.Zero, reference );
        Padding = new Q <V> ( normalizedPadding, V.Zero, reference );
        Position = new Q <V> ( normalizedPosition, V.Zero, reference );
    }

    public Disp (
        V normalizedSize,
        V normalizedPadding,
        V normalizedPosition,
        V reference
    )
        : this (
            V.Zero,
            normalizedSize,
            normalizedPadding,
            normalizedPosition,
            reference
        ) { }

    public Disp (
        V origin,
        V normalizedSize,
        V normalizedPadding,
        V normalizedPosition,
        V offsetSize,
        V offsetPadding,
        V offsetPosition,
        V reference
    ) {
        Origin = origin;
        Size = new Q <V> ( normalizedSize, offsetSize, reference );
        Padding = new Q <V> ( normalizedPadding, offsetPadding, reference );
        Position = new Q <V> ( normalizedPosition, offsetPosition, reference );
        // 0.1 0.3, 100 0, 1920 1080
        // 1920 + (1920 * 0.1)
    }

    public Q <V> Size { get; set; }
    public Q <V> Padding { get; set; }
    public Q <V> Position { get; set; }

    public V Origin { get; set; }

    public Texture2D Texture { get; set; }

    public AnchPos DrawAtHoriz { get; set; }
    public AnchPos DrawAtVert { get; set; }

    [Normal(false)]
    public V GetDrawOrigin ( ) {

        var drawPos = Origin + new V (
            (int) DrawAtHoriz * ( (Size.Reference.X - Size.Derived.X) / 2d ),
            (int) DrawAtVert * ( (Size.Reference.Y - Size.Derived.Y) / 2d )
        ) + new V (
            -( (int) DrawAtHoriz - 1) * Padding.Derived.X,
            -( (int) DrawAtVert - 1) * Padding.Derived.Y
        );

        return drawPos;

    }

    [Normal ( false )]
    public V GetDrawSize ( ) {
        return Size.Derived;
    }

    [Normal ( false )]
    public V GetDrawScale ( Texture2D tex ) {
        var scale = GetDrawSize ();
        var texScale = new V ( tex.Width, tex.Height );
        return texScale / scale;
    }

    [Normal ( false )]
    public V GetDrawScale ( int w, int h ) {
        var scale = GetDrawSize();
        var texScale = new V ( w, h );
        return texScale / scale;
    }

}