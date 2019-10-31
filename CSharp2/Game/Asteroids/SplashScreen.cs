using GameProject.Asteroids.GameLevels;
using System.Drawing;
using System.Windows.Forms;

namespace GameProject.Asteroids
{
    static class SplashScreen
    {
        static readonly Image background = Image.FromFile(@"Assets/BackGround1.jpg");
        public static void Init(Form form)
        {
            form.BackgroundImage = background;
            form.BackgroundImageLayout = ImageLayout.Stretch;

            Button play = new Button
            {
                Text = "Play",
                Width = 100,
                Height = 30
            };
            play.Location = new Point(form.Width - play.Width - 30, form.Height - 200);
            play.Click += (sender, e) =>
            {
                Game.Scene = new Level1();
                form.Controls.Clear();
                form.BackgroundImage = null;
                Game.Play();
            };

            Button records = new Button()
            {
                Text = "Records",
                Width = 100,
                Height = 30
            };
            records.Location = new Point(play.Location.X, play.Location.Y + play.Height + 10);

            Button exit = new Button()
            {
                Text = "Exit",
                Width = 100,
                Height = 30
            };
            exit.Location = new Point(records.Location.X, records.Location.Y + records.Height + 10);
            exit.Click += (sender, e) => form.Close();

            Button[] menu = { play, records, exit };
            form.Controls.AddRange(menu);
        }
    }
}
