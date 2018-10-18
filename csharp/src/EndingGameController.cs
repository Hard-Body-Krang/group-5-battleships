using SwinGameSDK;
// <summary>
// The EndingGameController is responsible for managing the interactions at the end
// of a game.
// </summary>
class EndingGameController {
    
    // <summary>
    // Draw the end of the game screen, shows the win/lose state
    // </summary>
    public static void DrawEndOfGame() {
        Rectangle toDraw = new Rectangle();
        string whatShouldIPrint;
        UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true); // draw field for end of game
        UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer); // draw small field for end of game
        toDraw.X = 0;
        toDraw.Y = 250;
        toDraw.Width = SwinGame.ScreenWidth();
        toDraw.Height = SwinGame.ScreenHeight();
        if (GameController.HumanPlayer.IsDestroyed) { // check if you lose
            whatShouldIPrint = "YOU LOSE!";
        }
        else {
            whatShouldIPrint = "-- WINNER --";
        }
        
        SwinGame.DrawText(whatShouldIPrint, Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw); // draw text for end game screen
    }
    
    // <summary>
    // Handle the input during the end of the game. Any interaction
    // will result in it reading in the highsSwinGame.
    // </summary>
    public static void HandleEndOfGameInput() {
        if ((SwinGame.MouseClicked(MouseButton.LeftButton) || (SwinGame.KeyTyped(KeyCode.ReturnKey) || SwinGame.KeyTyped(KeyCode.EscapeKey)))) {
            HighScoreController.ReadHighScore(GameController.HumanPlayer.Score); // open highscore
            GameController.EndCurrentState();
        }
        
    }
}