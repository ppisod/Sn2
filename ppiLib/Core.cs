using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ppiLib;

/// <summary>
/// a singleton class to handle all basic game functionalities... GraphicsDeviceManager, SpriteBatch etc.
/// </summary>
public class Core : Game
{
    internal static Core thisInstance;
    public static Core Instance => thisInstance;

    public static Color BackgroundColor { get; set; } = Color.CornflowerBlue;
    
    public static GraphicsDeviceManager DeviceManager { get; private set; }
    
    public new static GraphicsDevice GraphicsDevice { get; private set; }
    
    public static SpriteBatch SpriteBatch { get; private set; }
    
    public static ContentManager ContentManager { get; private set; }

    public Core(string windowTitle, int width, int height, bool fullscreen)
    {
        if (thisInstance != null) throw new InvalidOperationException("Only a single Core instance is allowed.");

        thisInstance = this;
        DeviceManager = new GraphicsDeviceManager(this);

        DeviceManager.PreferredBackBufferWidth = width;
        DeviceManager.PreferredBackBufferHeight = height;
        DeviceManager.IsFullScreen = fullscreen;

        GraphicsDevice = DeviceManager.GraphicsDevice;
        
        DeviceManager.ApplyChanges();

        Window.Title = windowTitle;

        ContentManager = Content;
        
        ContentManager.RootDirectory = "Content";
        
        IsMouseVisible = true;
    }

    protected virtual void ini ( ) { }
    protected virtual void upd ( GameTime gT ) { }
    protected virtual void draw ( GameTime gT ) { }

    protected override void Initialize ( ) {
        ini ();
        base.Initialize ();
    }

    protected override void Draw ( GameTime gameTime ) {
        base.GraphicsDevice.Clear(BackgroundColor);
        draw (gameTime);
        base.Draw ( gameTime );
    }

    protected override void Update ( GameTime gameTime ) {
        upd (gameTime);

        // exit
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        base.Update ( gameTime );
    }
}