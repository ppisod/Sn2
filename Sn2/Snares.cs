using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ppiLib;
using Sn2.Lib.State;

namespace Sn2;

public class Snares ( )
    : Core (
        "Snares-v0.2",
        1920,
        1080,
        true
    ) {

    private StateControllerSnares cont;

    protected override void ini ( ) {
        base.ini ();
        cont = new StateControllerSnares ( GraphicsDevice, 1920, 1080 );
    }

    protected override void draw ( GameTime gT ) {
        base.draw ( gT );
        cont.draw ( SpriteBatch );
    }

    protected override void upd ( GameTime gT ) {
        base.upd ( gT );
    }
}