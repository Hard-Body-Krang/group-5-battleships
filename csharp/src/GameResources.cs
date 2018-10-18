using SwinGameSDK;
using System;
using System.Collections.Generic;
public class GameResources {
    
    private static void LoadFonts() {
        NewFont("ArialLarge", "arial.ttf", 80);
        NewFont("Courier", "cour.ttf", 14);
        NewFont("CourierSmall", "cour.ttf", 8);
        NewFont("Menu", "ffaccess.ttf", 8);
    }
    
    private static void LoadImages() {
        // Backgrounds
        NewImage("Menu", "main_page.jpg");
        NewImage("Discovery", "discover.jpg");
        NewImage("Deploy", "deploy.jpg");
        // Deployment
        NewImage("LeftRightButton", "deploy_dir_button_horiz.png");
        NewImage("UpDownButton", "deploy_dir_button_vert.png");
        NewImage("SelectedShip", "deploy_button_hl.png");
        NewImage("PlayButton", "deploy_play_button.png");
        NewImage("RandomButton", "deploy_randomize_button.png");
        // Ships
        for (int i = 1; i <= 5; i++) {
            NewImage(("ShipLR" + i), ("ship_deploy_horiz_" + (i + ".png")));
            NewImage(("ShipUD" + i), ("ship_deploy_vert_"  + (i + ".png")));
        }
        
        // Explosions
        NewImage("Explosion", "explosion.png");
        NewImage("Splash", "splash.png");
    }
    
    private static void LoadSounds() {
		// sound effect
        NewSound("Error", "error.wav");
        NewSound("Hit", "hit.wav");
        NewSound("Sink", "sink.wav");
        NewSound("Miss", "watershot.wav");
        NewSound("Winner", "winner.wav");
        NewSound("Lose", "lose.wav");
    }
    
    private static void LoadMusic()
    {   // music
        NewMusic("Background", "soundtrack.mp3");
    }
    
    // '' <summary>
    // '' Gets a Font Loaded in the Resources
    // '' </summary>
    // '' <param name="font">Name of Font</param>
    // '' <returns>The Font Loaded with this Name</returns>
    public static Font GameFont(string font)
    {
        return _Fonts[font];
    }
    
    // '' <summary>
    // '' Gets an Image loaded in the Resources
    // '' </summary>
    // '' <param name="image">Name of image</param>
    // '' <returns>The image loaded with this name</returns>
    public static Bitmap GameImage(string image)
    {
        return _Images[image];
    }
    
    // '' <summary>
    // '' Gets an sound loaded in the Resources
    // '' </summary>
    // '' <param name="sound">Name of sound</param>
    // '' <returns>The sound with this name</returns>
    public static SoundEffect GameSound(string sound) {
        return _Sounds[sound];
    }
    
    // '' <summary>
    // '' Gets the music loaded in the Resources
    // '' </summary>
    // '' <param name="music">Name of music</param>
    // '' <returns>The music with this name</returns>
    public static Music GameMusic(string music) {
        return _Music[music];
    }
    
    private static Dictionary<string, Bitmap> _Images = new Dictionary<string, Bitmap>();
    
    private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font>();
    
    private static Dictionary<string, SoundEffect> _Sounds = new Dictionary<string, SoundEffect>();
    
    private static Dictionary<string, Music> _Music = new Dictionary<string, Music>();
    
    private static Bitmap _Background;
    
    private static Bitmap _Animation;
    
    private static Bitmap _LoaderFull;
    
    private static Bitmap _LoaderEmpty;
    
    private static Font _LoadingFont;
    
    private static SoundEffect _StartSound;
    
    // '' <summary>
    // '' The Resources Class stores all of the Games Media Resources, such as Images, Fonts
    // '' Sounds, Music.
    // '' </summary>
    public static void LoadResources() { // loading all resources
        int width;
        int height;
        width = SwinGame.ScreenWidth();
        height = SwinGame.ScreenHeight();
        SwinGame.ChangeScreenSize(800, 600);
        ShowLoadingScreen();
        ShowMessage("Loading fonts...", 0);
        LoadFonts();
        SwinGame.Delay(100);
        ShowMessage("Loading images...", 1);
        LoadImages();
        SwinGame.Delay(100);
        ShowMessage("Loading sounds...", 2);
        LoadSounds();
        SwinGame.Delay(100);
        ShowMessage("Loading music...", 3);
        LoadMusic();
        SwinGame.Delay(100);
        SwinGame.Delay(100);
        ShowMessage("Game loaded...", 5);
        SwinGame.Delay(100);
        EndLoadingScreen(width, height);
    }
    
    private static void ShowLoadingScreen() {
        _Background = SwinGame.LoadBitmap(SwinGame.PathToResource("SplashBack.png", ResourceKind.BitmapResource));
        SwinGame.DrawBitmap(_Background, 0, 0);
        SwinGame.RefreshScreen();
        SwinGame.ProcessEvents();
        _Animation = SwinGame.LoadBitmap(SwinGame.PathToResource("SwinGameAni.jpg", ResourceKind.BitmapResource));
        _LoadingFont = SwinGame.LoadFont(SwinGame.PathToResource("arial.ttf", ResourceKind.FontResource), 12);
        _StartSound = Audio.LoadSoundEffect(SwinGame.PathToResource("SwinGameStart.ogg", ResourceKind.SoundResource));
        _LoaderFull = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_full.png", ResourceKind.BitmapResource));
        _LoaderEmpty = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_empty.png", ResourceKind.BitmapResource));
        PlaySwinGameIntro();
    }
    
    private static void PlaySwinGameIntro() {
        const int ANI_CELL_COUNT = 11;
        Audio.PlaySoundEffect(_StartSound);
        SwinGame.Delay(200);
        int i;
        for (i = 0; (i  // play the intro by refreshing screen and draw the screen
                    <= (ANI_CELL_COUNT - 1)); i++) {
            SwinGame.DrawBitmap(_Background, 0, 0);
            SwinGame.Delay(20);
            SwinGame.RefreshScreen();
            SwinGame.ProcessEvents();
        }
        
        SwinGame.Delay(1500);
    }
    
    private static void ShowMessage(string message, int number) {
        const int BG_Y = 453;
        int TX = 310;
        int TY = 493;
        int TW = 200;
        int TH = 25;
        int STEPS = 5;
        int BG_X = 279;
        int fullW;
        Rectangle toDraw = new Rectangle();
        fullW = (260 * number / STEPS);

        SwinGame.DrawBitmap(_LoaderEmpty, BG_X, BG_Y);
        SwinGame.DrawCell(_LoaderFull, 0, BG_X, BG_Y);
        // SwinGame.DrawBitmapPart(_LoaderFull, 0, 0, fullW, 66, BG_X, BG_Y)
        toDraw.X = TX;
        toDraw.Y = TY;
        toDraw.Width = TW;
        toDraw.Height = TH;
    
        SwinGame.DrawText(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, toDraw);
        //  SwinGame.DrawTextLines(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, TX, TY, TW, TH)
        SwinGame.RefreshScreen();
        SwinGame.ProcessEvents();
    }
    
    private static void EndLoadingScreen(int width, int height) {
        SwinGame.ProcessEvents();
        SwinGame.Delay(500);
        SwinGame.ClearScreen();
        SwinGame.RefreshScreen();
        SwinGame.FreeFont(_LoadingFont);
        SwinGame.FreeBitmap(_Background);
        SwinGame.FreeBitmap(_Animation);
        SwinGame.FreeBitmap(_LoaderEmpty);
        SwinGame.FreeBitmap(_LoaderFull);
//Audio.FreeSoundEffect(_StartSound);
        SwinGame.ChangeScreenSize(width, height);
    }
    
    private static void NewFont(string fontName, string filename, int size) {
        _Fonts.Add(fontName, SwinGame.LoadFont(SwinGame.PathToResource(filename, ResourceKind.FontResource), size)); // add new font
    }
    
    private static void NewImage(string imageName, string filename) {
        _Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource))); // add new image
    }
    
    private static void NewTransparentColorImage(string imageName, string fileName, Color transColor) {
        _Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(fileName, ResourceKind.BitmapResource))); 
    }
    
    private static void NewTransparentColourImage(string imageName, string fileName, Color transColor) {
        NewTransparentColorImage(imageName, fileName, transColor);
    }
    
    private static void NewSound(string soundName, string filename) {
        _Sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource))); // add new sound
    }
    
    private static void NewMusic(string musicName, string filename) {
        _Music.Add(musicName, Audio.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.SoundResource))); // add new music
    }
    
    private static void FreeFonts()
    {
        foreach (Font obj in _Fonts.Values) {
            SwinGame.FreeFont(obj);
        }
        
    }
    
    private static void FreeImages() {
   
        foreach (Bitmap obj in _Images.Values) {
            SwinGame.FreeBitmap(obj);
        }
        
    }
    
    private static void FreeSounds()
    {
        Audio.ReleaseAllSoundEffects();
    }
    
    private static void FreeMusic()
    {
        Audio.ReleaseAllMusic();
             
    }
    
    public static void FreeResources() {
        FreeFonts();
        FreeImages();
        FreeMusic();
        FreeSounds();
        SwinGame.ProcessEvents();
    }
}