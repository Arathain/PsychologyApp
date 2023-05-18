using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PsychologyApp.code;

namespace PsychologyApp {
	class PsychologyAppGame : Game {
		private MouseState prevMouse = new MouseState();
		GraphicsDeviceManager graphics;
		public Screen currentScreen;

		private int width, height;
		private Vector2 centre;
		public static int[] intervals = new int[]{
			14100,
			14900,
			16300,
			16200,
			10100,
			14200,
			17100,
			11200,
			17000,
			15700,
			18400,
			14600,
			19200,
			18400,
			12100,
			17000,
			11200,
			10900,
			19600,
			15700,
			13800,
			13900,
			18500,
			12700,
			14900,
			16700,
			15500
		};

		public Vector2 getCentre() {
			if(centre.X != width/2 || centre.Y != height/2) {
				centre = new Vector2(width/2, height/2);
			}
			return centre;
		}

		public PsychologyAppGame() {
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = width =  1920;
			graphics.PreferredBackBufferHeight = height = 1080;
			graphics.PreferMultiSampling = true;
			Content.RootDirectory = "Content";

			Window.AllowUserResizing = true;
			IsMouseVisible = true;
			List<ScreenObject> s = new List<ScreenObject>();
			s.Add(new StopButton(0, 0));
			s.Add(new BlueLight(-30, -20));
			s.Add(new OrangeLight(30, -20));
			currentScreen = new InstTestScreen(s);
		}

		protected override void LoadContent() {
			base.LoadContent();
			ContentDocks.load(Content);
			currentScreen.load(graphics.GraphicsDevice, Content);
		}

		protected override void UnloadContent() {
			base.UnloadContent();
			ContentDocks.unload();
			currentScreen.unload();
		}

		protected override void Update(GameTime gameTime) {
			width = Window.ClientBounds.Width;
			height = Window.ClientBounds.Height;
			MouseState mouse = Mouse.GetState();

			currentScreen.update(gameTime, mouse, prevMouse);

			base.Update(gameTime);
			prevMouse = mouse;
		}

		protected override void Draw(GameTime gameTime) {
			//
			// Replace this with your own drawing code.
			//

			GraphicsDevice.Clear(Color.SlateGray);
			currentScreen.draw(gameTime);
			base.Draw(gameTime);
		}
	}
}
