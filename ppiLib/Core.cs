using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ppiLib;

/// <summary>
/// a singleton class to handle all basic game functionalities... GraphicsDeviceManager, SpriteBatch etc.
/// </summary>
public class Core : Game
{
    internal static Core thisInstance;
    public static Core Instance => thisInstance;
    
    public static GraphicsDeviceManager DeviceManager { get; private set; }
    
    public new static GraphicsDevice GraphicsDevice { get; private set; }
    
    public static SpriteBatch SpriteBatch { get; private set; }
    
    public static ContentManager ContentManager { get; private set; }

    public Core(string windowTitle, int width, int height, bool fullscreen)
    {
        if (thisInstance != null) throw new InvalidOperationException("Only a single Core instance.");

        thisInstance = this;
        DeviceManager =  new GraphicsDeviceManager(this);

        DeviceManager.PreferredBackBufferWidth = width;
        DeviceManager.PreferredBackBufferHeight = height;
        DeviceManager.IsFullScreen = fullscreen;
        
        DeviceManager.ApplyChanges();

        Window.Title = windowTitle;

        ContentManager = Content;
        
        ContentManager.RootDirectory = "Content";
        
        IsMouseVisible = true;
    }
}