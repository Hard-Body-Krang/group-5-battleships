using SwinGameSDK;
using System;
using System.Collections.Generic;

//  <summary>
//  The battle phase is handled by the DiscoveryController.
//  </summary>
class DiscoveryController {
   
    //  <summary>
    //  Handles input during the discovery phase of the game.
    //  </summary>
    //  <remarks>
    //  Escape opens the game menu. Clicking the mouse will
    //  attack a location.
    //  </remarks>
    public static void HandleDiscoveryInput() {
        if (SwinGame.KeyTyped(KeyCode.EscapeKey)) { // condition if esc key is pressed
            GameController.AddNewState(GameState.ViewingGameMenu);
        }
        
        if (SwinGame.MouseClicked(MouseButton.LeftButton)) { // condition if m1 key is pressed
            DiscoveryController.DoAttack();
        }
        
    }
    
    //  <summary>
    //  Attack the location that the mouse if over.
    //  </summary>
    private static void DoAttack() {
        Point2D mouse = default(Point2D);
        mouse = SwinGame.MousePosition();
        // Calculate the row/col clicked

        int row = Convert.ToInt32(Math.Floor(((mouse.Y - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)))); // draw grid row
        int col = Convert.ToInt32(Math.Floor(((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)))); // draw grid column
        if (((row >= 0) && (row < GameController.HumanPlayer.EnemyGrid.Height))) { // check if its a valid space to do attack
            if (((col >= 0) && (col < GameController.HumanPlayer.EnemyGrid.Width))) {
                GameController.Attack(row, col); //  commence  attack
            }
        }
    }
    
    //  <summary>
    //  Draws the game during the attack phase.
    //  </summary>s
    public static void DrawDiscovery() {
        const int SCORES_LEFT = 172;
        const int SHOTS_TOP = 157;
        const int HITS_TOP = 206;
        const int SPLASH_TOP = 256;
        if ((SwinGame.KeyDown(KeyCode.LeftShiftKey) || SwinGame.KeyDown(KeyCode.RightShiftKey)) && SwinGame.KeyDown(KeyCode.CKey)) 
        {
            // TODO - understand what this does
            UtilityFunctions.DrawField(GameController.HumanPlayer.EnemyGrid, GameController.ComputerPlayer, true); // This is what happen if enemy's ship discovered
            // BUG - possible bug as I believe that ships should be displayed
        }
        else {
            UtilityFunctions.DrawField(GameController.HumanPlayer.EnemyGrid, GameController.ComputerPlayer, false); // this is when you fails to discover enemy ship
        }

        UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);
        UtilityFunctions.DrawMessage(); // draw message
        SwinGame.DrawText(GameController.HumanPlayer.Shots.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SHOTS_TOP);
        SwinGame.DrawText(GameController.HumanPlayer.Hits.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, HITS_TOP);
        SwinGame.DrawText(GameController.HumanPlayer.Missed.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SPLASH_TOP);
    }
}