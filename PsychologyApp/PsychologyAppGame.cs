using System.Collections.Generic;
using System.IO;
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using PsychologyApp.code;

namespace PsychologyApp {
	class PsychologyAppGame : Game {
		private MouseState prevMouse = new MouseState();
		GraphicsDeviceManager graphics;
		public Screen currentScreen;

		private int width, height;
		private Vector2 centre;
		private SpriteBatch batch;
		public bool escapeable;
		public int subjectOrdinal = 0;
		public List<int> responseIntervalTotallyNotTelemetry = new List<int>();
		public List<int> anagramResponseIntervalTotallyNotTelemetry = new List<int>();
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
			s.Add(new StartButton(0, 0));
			s.Add(new SoundButton(60, -40));
			currentScreen = new StartScreen(s);
			escapeable = new Random().Next(2) == 0;
			Console.WriteLine(escapeable);
			//currentScreen = new AnagramTestScreen(new List<ScreenObject>());
			//StartTextInput();
		}

		protected override void LoadContent() {
			base.LoadContent();
			ContentDocks.load(Content);
			LetterDocks.load(Content);
			batch = new SpriteBatch(graphics.GraphicsDevice);
		}

		
	//directly taken from the FNA wiki
	public void DoStorageContainerThing() {
	// 	IAsyncResult result;

	// 	result = StorageDevice.BeginShowSelector(null, null);
	// 	while (!result.IsCompleted)
	// 	{
	// 		// Just hang out for a bit...
	// 		System.Threading.Thread.Sleep(1);
	// 	}
	// 	StorageDevice device = StorageDevice.EndShowSelector(result);

	// 	result = device.BeginOpenContainer("SaveData", null, null);
	// 	while (!result.IsCompleted)
	// 	{
	// 		// Just hang out for a bit...
	// 		System.Threading.Thread.Sleep(1);
	// 	}
	// 	StorageContainer container = device.EndOpenContainer(result);

	// 	// Do stuff!
	// 	while(container.FileExists("subject_" + subjectOrdinal + ".txt")) {
	// 		subjectOrdinal++;
	// 	}
	// 	StreamWriter writer = new StreamWriter(container.CreateFile("subject_" + subjectOrdinal + ".txt"));
		// writer.WriteLine("escapeable: " + escapeable);
		// writer.WriteLine("button response times, if any:");
		// foreach(int i in responseIntervalTotallyNotTelemetry) {
		// 	writer.WriteLine(i);
		// }
		// writer.WriteLine("anagram response times, if any:");
		// foreach(int i in anagramResponseIntervalTotallyNotTelemetry) {
		// 	writer.WriteLine(i);
		// }
		Console.WriteLine("escapeable: " + escapeable);
		Console.WriteLine("button response times, if any:");
		foreach(int i in responseIntervalTotallyNotTelemetry) {
			Console.WriteLine(i/1000f);
		}
		Console.WriteLine("anagram response times, if any:");
		foreach(int i in anagramResponseIntervalTotallyNotTelemetry) {
			Console.WriteLine(i/1000f);
		}
		
		// Clean up after yourself! Maybe keep `device` from getting collected.
		//writer.Close();
		//container.Dispose();
	}

		protected override void UnloadContent() {
			base.UnloadContent();
			ContentDocks.unload();
			LetterDocks.unload();
			if(batch != null && !batch.IsDisposed) {
				batch.Dispose();
			}
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

			GraphicsDevice.Clear(Color.Gray);
			currentScreen.draw(gameTime, batch);
			base.Draw(gameTime);
		}
		private void OnTextInput(char c) {
			bool b = c == (char) 8 || c == (char) 127;
			if(c == (char) 13 && currentScreen is InstTestScreen s) {
				s.resetTimer();
				StopTextInput();
			}
			if((LetterDocks.isSupported(c) || b) && currentScreen is KeyListenerScreen a) {
				if(b) {
					a.clearInput();
				} else {
					a.addChar(c);
				}
			}	
		}

		public void StartTextInput()
		{
			TextInputEXT.TextInput += OnTextInput;
			TextInputEXT.StartTextInput();
		}

		public void StopTextInput()
		{
			TextInputEXT.StopTextInput();
			TextInputEXT.TextInput -= OnTextInput;
		}
	}
}
