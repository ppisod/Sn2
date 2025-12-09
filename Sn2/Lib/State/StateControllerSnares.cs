using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ppiLib.Types;
using Sn2.Lib.Generators;

namespace Sn2.Lib.State;

/// <summary>
/// stores all info/data.
/// This is a temporary thing! abstracting should remove the need for this class.
/// Things may seem obtuse but this is just a way for me to map out what
/// to implement in my node classes.
/// </summary>
public class StateControllerSnares {

    private int w;
    private int h;
    private GraphicsDevice device;

    private Texture2D texLightGray;
    private Texture2D texGray;
    private Texture2D texDarkGray;

    // W or H
    public double WidthTrack = 0.8;
    public double HeightTrack = 0.15;

    // in terms of parent W or H
    public double HeightSubTrack = 0.3; // parented to Slider
    public double WidthSubTrack = 1; // parented to Slider

    public double HeightSlider = 1.5; // parented to SubTrack
    public double WidthSlider = 0.02; // parented to SubTrack

    public double SliderProgress = 0;

    public StateControllerSnares ( GraphicsDevice device, int w, int h ) {
        this.w = w;
        this.h = h;
        this.device = device;

        texLightGray = GenTex.GenerateSquare (
            device,
            1,
            1,
            new Color (
                135,
                135,
                135,
                255
            )
        );

        texGray = GenTex.GenerateSquare (
            device,
            1,
            1,
            new Color (
                200,
                200,
                200,
                255
            )
        );

        texDarkGray = GenTex.GenerateSquare (
            device,
            1,
            1,
            new Color (
                235,
                235,
                235,
                255
            )
        );

    }

    public void draw ( SpriteBatch spriteBatch ) {
        spriteBatch.Begin (  );
        // Draw the Track first!
        var trackSize = new V ( w * WidthTrack, h * HeightTrack );
        var trackOrigin = new V ( 0 + ( w - trackSize.X ) / 2, 0 + ( h - trackSize.Y ) / 2 ); // mode: center
        var trackScale = new V ( trackSize.X / texLightGray.Width, trackSize.Y / texLightGray.Height );
        spriteBatch.Draw (
            texLightGray,
            trackOrigin.ToVector2 (),
            null,
            Color.White,
            0f,
            Vector2.Zero,
            trackScale.ToVector2 (),
            SpriteEffects.None,
            1
        );

        // then draw subtrack
        var subTrackSize = new V ( trackSize.X * WidthSubTrack, trackSize.Y * HeightSubTrack );
        var subTrackOrigin = new V ( trackOrigin.X + 0, trackOrigin.Y + ( trackSize.Y - subTrackSize.Y ) / 2 ); // mode: left-cent
        var subTrackScale = new V ( subTrackSize.X / texGray.Width, subTrackSize.Y / texGray.Height );
        spriteBatch.Draw (
            texGray,
            subTrackOrigin.ToVector2 (),
            null,
            Color.White,
            0f,
            Vector2.Zero,
            subTrackScale.ToVector2 (),
            SpriteEffects.None,
            1
        );

        // then draw slider
        var sliderSize = new V ( subTrackSize.X * WidthSlider, subTrackSize.Y * HeightSlider );
        var sliderOrigin = new V ( subTrackOrigin.X + 0, subTrackOrigin.Y + (subTrackSize.Y - sliderSize.Y) / 2 ); // mode: left-cent
        var sliderScale = new V ( sliderSize.X / texDarkGray.Width, sliderSize.Y / texDarkGray.Height );
        spriteBatch.Draw (
            texDarkGray,
            sliderOrigin.ToVector2 (),
            null,
            Color.White,
            0f,
            Vector2.Zero,
            sliderScale.ToVector2 (),
            SpriteEffects.None,
            1
        );
        spriteBatch.End ();
    }

}