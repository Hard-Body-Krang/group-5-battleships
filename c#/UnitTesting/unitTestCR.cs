/*﻿using NUnit.Framework;
using System;
using SwinGameSDK;

namespace Application
{
	[TestFixture ()]
	public class Battleship_Unit_Tests2
	{
		[Test ()]
		public void TestTugDestT ()
		{
			Ship s = new Ship (ShipName.Tug);

			s.Hit ();

			Assert.IsTrue(s.IsDestroyed);
		}

		[Test ()]
		public void TestSubShipDestT ()
		{
			Ship s = new Ship (ShipName.Submarine);

			s.Hit ();
			s.Hit ();

			Assert.IsTrue(s.IsDestroyed);
		}

		[Test ()]
		public void TestDestShipDestT ()
		{
			Ship s = new Ship (ShipName.Destroyer);

			s.Hit ();
			s.Hit ();
			s.Hit ();

			Assert.IsTrue(s.IsDestroyed);
		}

		[Test ()]
		public void TestBattleShipDestT ()
		{
			Ship s = new Ship (ShipName.Battleship);

			s.Hit ();
			s.Hit ();
			s.Hit ();
			s.Hit ();

			Assert.IsTrue(s.IsDestroyed);
		}

		[Test ()]
		public void TestACShipDestT ()
		{
			Ship s = new Ship (ShipName.AircraftCarrier);

			s.Hit ();
			s.Hit ();
			s.Hit ();
			s.Hit ();
			s.Hit ();

			Assert.IsTrue(s.IsDestroyed);
		}

		[Test ()]
		public void TestCaseDir2 ()
		{
			Ship s = new Ship (ShipName.Tug);

			s.Hit ();

			Assert.IsTrue(s.IsDestroyed);
		}






		[Test ()]
		public void TestAddShip ()
		{
			BattleShipsGame game = new BattleShipsGame();

			Player p = new Player (game);

			SeaGrid sg = p.PlayerGrid;

			Ship s = new Ship (ShipName.Destroyer);

			sg.AddShip (1, 1, Direction.LeftRight, s);

			TileView t = sg[1,1];

			Assert.AreEqual (t, TileView.Ship);
		}


		[Test ()]
		public void TestMoveShip ()
		{
			BattleShipsGame game = new BattleShipsGame();

			Player p = new Player (game);

			SeaGrid sg = p.PlayerGrid;

			Ship s = new Ship (ShipName.Destroyer);

			sg.AddShip (1, 1, Direction.LeftRight, s);

			sg.MoveShip (5, 5, ShipName.Destroyer, Direction.UpDown);

			TileView t = sg[5,5];

			Assert.AreEqual (t, TileView.Ship);
		}

		[Test ()]
		public void TestDCShip ()
		{
			BattleShipsGame game = new BattleShipsGame();

			Player p = new Player (game);

			SeaGrid sg = p.PlayerGrid;

			Ship s = new Ship (ShipName.Destroyer);

			sg.AddShip (2, 2, Direction.LeftRight, s);

			DeploymentController.DoDeployClick (sg);

			TileView t = sg[1,1];

			Assert.AreEqual (t, TileView.Ship);
		}



		[Test ()]
		public void TestCase3 ()
		{


			Point2D mouse = default(Point2D);

			mouse = SwinGame.PointAt (1, 180);

			int row = 0;
			int col = 0;
			row = Convert.ToInt32(Math.Floor((mouse.Y  - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
			col = Convert.ToInt32(Math.Floor((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));

			Assert.AreEqual (row, 1);
			Assert.IsTrue (col < 0);
		}

		[Test ()]
		public void PointInCubeRow1Col1 ()
		{
			Point2D mouse = default(Point2D);

			mouse = SwinGame.PointAt (400, 180);

			int row = 0;
			int col = 0;
			row = Convert.ToInt32(Math.Floor((mouse.Y  - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
			col = Convert.ToInt32(Math.Floor((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));

			Assert.AreEqual (row, 1);
			Assert.AreEqual (col, 1);
		}

	
	}
}*/
