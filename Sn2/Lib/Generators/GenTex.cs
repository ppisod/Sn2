using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sn2.Lib.Generators;

public static class GenTex {

    // ImageManipulation reference?
    public static Texture2D GenerateSquare ( GraphicsDevice G, int w, int h, Color color) {
        var J = new Texture2D ( G, w, h );
        // should be w * h
        var k = new Color[w * h];

        for (var i = 0; i < w * h; i++)
        {
            k[i] = color;
        }
        J.SetData ( k );
        return J;
    }

}