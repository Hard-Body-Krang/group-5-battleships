
using System.Collections.Generic;
using System.IO;
using System;

using SwinGameSDK;
// '' <summary>
// '' Controls displaying and collecting high score data.
// '' </summary>
// '' <remarks>
// '' Data is saved to a file.
// '' </remarks>
class HowToController {
    
    private const int TEXT_WIDTH = 3;
    private const int SCORES_LEFT = 490;
   

    private static List<string> _Text = new List<string>();

    private static void LoadText()
    {
        string filename;
        filename = SwinGame.PathToResource("howtotext.txt");
        StreamReader input;
        input = new StreamReader(filename);
        string line;
        while ((line = input.ReadLine()) != null)
        {
            _Text.Add(line);
        }
        input.Close();
    }

   
    // '' <summary>
    // '' Draws the high scores to the screen.
    // '' </summary>
    public static void DrawHowTo() {
        if (_Text.Count == 0)
        {
            LoadText();
        }
        List<string> Text = _Text;
        const int SCORES_HEADING = 40;
        Rectangle textBox = new Rectangle();
        textBox.X = SCORES_LEFT - 100;
        textBox.Y = SCORES_HEADING + 20;
        textBox.Width = 300;
        textBox.Height = 500;
        SwinGame.DrawRectangle(Color.Blue, textBox);
        SwinGame.DrawText("   How To Play  ", Color.White, GameResources.GameFont("Courier"), SCORES_LEFT, SCORES_HEADING);
        for (int i = 0; i < Text.Count; i++)
        {
            SwinGame.DrawText(Text[i], Color.White, GameResources.GameFont("Courier"), textBox.X + 10, SCORES_HEADING + 10 + 10 * (i + 1));
        }
    }

    // '' <summary>
    // '' Handles the user input during the top score screen.
    // '' </summary>
    // '' <remarks></remarks>
    public static void HandleHowToInput()
    {
        if ((SwinGame.MouseClicked(MouseButton.LeftButton) || (SwinGame.KeyTyped(KeyCode.EscapeKey) || SwinGame.KeyTyped(KeyCode.ReturnKey))))
        {
            GameController.EndCurrentState();
        }
    }

}