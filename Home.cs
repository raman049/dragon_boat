using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace com.dragon_boat
{
	public class Home
	{

		SpriteFont font;
		Texture2D t2d_button_play, t2d_button_instruction, t2d_dragon;
		Button button_play, button_instruction;
		int height, width;
		public Home(GraphicsDevice graphicsDevice)
		{
			height = graphicsDevice.Viewport.Height;
			width = graphicsDevice.Viewport.Width;
			button_play = new Button(graphicsDevice, new Rectangle((int)(width / 2 - width * 0.1), (int)(height * 0.60f), (int)(width * 0.2), (int)(width * 0.2)));
			button_instruction = new Button(graphicsDevice, new Rectangle((int)(width / 2 - width * 0.1), (int)(height * 0.8f), (int)(width * 0.2), (int)(width * 0.2)));
			if (t2d_button_play == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/button_play.png"))
				{
					t2d_button_play = Texture2D.FromStream(graphicsDevice, stream);
				}
			}
			if (t2d_button_instruction == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/button_instruction.png"))
				{
					t2d_button_instruction = Texture2D.FromStream(graphicsDevice, stream);
				}
			}
			if (t2d_dragon == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/dragon5.png"))
				{
					t2d_dragon = Texture2D.FromStream(graphicsDevice, stream);
				}
			}
		}
		public void LoadContent(ContentManager content)
		{
			font = content.Load<SpriteFont>("AlphaWoodFont");
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			Color tintColor = Color.White;
			String a = "DRAGON BOAT";
			Vector2 textMiddlePoint = font.MeasureString(a) / 2;
			spriteBatch.Draw(t2d_dragon, new Rectangle(10, (int)(height * 0.05), width - 10, height - 10), tintColor * 0.5f);
			spriteBatch.DrawString(font, a, new Vector2(width / 2, height / 2), Color.Red, 0, textMiddlePoint, 1.5f, 0, 0);
			button_play.DrawT2dButton(spriteBatch, t2d_button_play);
			button_instruction.DrawT2dButton(spriteBatch, t2d_button_instruction);

		}
		TouchCollection touchCollection;
		public void updateButton(GraphicsDevice graphicsDevice)
		{
			touchCollection = TouchPanel.GetState();
			if (button_play.touchSelect(touchCollection))
			{
				//moveLeft();
				Play_button = true;
				Console.WriteLine("button play 1");
				unloadAll();
			}
			if (button_instruction.touchSelect(touchCollection))
			{
				//moveRight();
				Console.WriteLine("button instruction");
			}
		}
		public Boolean Play_button { get; set; }
		public void unloadAll()
		{
			t2d_button_play.Dispose();
			t2d_button_instruction.Dispose();
			t2d_dragon.Dispose();


		}
		public void UnloadContent(ContentManager content)

		{

			content.Unload();

		}

	}
}
