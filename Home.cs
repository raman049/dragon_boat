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
		Texture2D t2d_button, t2d_dragon;
		Button button_play;
		int height, width;
		Rectangle playButtonRect;
		public Home(GraphicsDevice graphicsDevice)
		{
			height = graphicsDevice.Viewport.Height;
			width = graphicsDevice.Viewport.Width;
			playButtonRect = new Rectangle((int)(width / 2 - width * 0.1), (int)(height * 0.60f), (int)(width /2), (int)(width*0.2));
			button_play = new Button(graphicsDevice, playButtonRect);
				if (t2d_button == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/paddle_buttons.png"))
				{
					t2d_button = Texture2D.FromStream(graphicsDevice, stream);
				}
			}

			if (t2d_dragon == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/dragon_boat.png"))
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
			spriteBatch.Draw(t2d_dragon, new Vector2(10,10), tintColor * 0.5f);
			spriteBatch.DrawString(font, a, new Vector2(width / 2, height / 2), Color.Red, 0, textMiddlePoint, 1.5f, 0, 0);
			spriteBatch.Draw(t2d_button, playButtonRect, new Rectangle(0, 0, 400, 100), tintColor);

		}
		TouchCollection touchCollection;
		public void updateButton(GraphicsDevice graphicsDevice)
		{
			touchCollection = TouchPanel.GetState();
			if (button_play.touchSelect(touchCollection))
			{
				//moveLeft();
				Play_button = true;
				//unloadAll();
			}

		}
		public Boolean Play_button { get; set; }
		public void unloadAll()
		{
			//t2d_button_play.Dispose();
			t2d_dragon.Dispose();


		}
		public void UnloadContent(ContentManager content)

		{

			content.Unload();

		}

	}
}
