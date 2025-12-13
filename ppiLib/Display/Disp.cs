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
    public Rela DrawAt { get; set; }

    [Normal(false)]
    public V GetDrawOrigin ( ) {

        V initialDrawPos;

        switch (DrawAt)
        {
            case Rela.TopLeft:
                initialDrawPos = Origin + Padding.Derived;
                break;
            case Rela.TopMiddle:
                initialDrawPos = new V (
                    Padding.Derived.X + Origin.X + ( Size.Reference.X - Size.Derived.X ) / 2,
                    Padding.Derived.Y + Origin.Y
                );
                break;
            case Rela.TopRight:
                initialDrawPos = new V (
                    Origin.X + ( Size.Reference.X - Size.Derived.X ) + Padding.Derived.X,
                    Padding.Derived.Y + Origin.Y
                );
                break;
            case Rela.MiddleLeft:
                initialDrawPos = new V (
                    Origin.X + Padding.Derived.X,
                    Origin.Y + ( Size.Reference.Y - Size.Derived.Y ) / 2
                );
                break;
            case Rela.Middle:
                initialDrawPos = new V (
                    Origin.X + ( Size.Reference.X - Size.Derived.X ) / 2,
                    Origin.Y + ( Size.Reference.Y - Size.Derived.Y ) / 2
                );
                break;
            case Rela.MiddleRight:
                break;
            case Rela.BottomLeft:
                break;
            case Rela.BottomMiddle:
                break;
            case Rela.BottomRight:
                break;
            default:
                break;
        }
    }

}