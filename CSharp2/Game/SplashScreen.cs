using GameEngineLibraryProject;
using GameProject.Asteroids.GameLevels;
using GameProject.Asteroids.GameObjects;
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
                form.Controls.Clear();
                form.BackgroundImage = null;
                form.KeyDown += Form_ShootKeyDown;
                form.KeyDown += Form_MoveKeyDown;
                MainGame.Start();
                Program.Log?.Invoke(null, "SplashScreen Button: play - pressed");
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
            exit.Click += (sender, e) =>
            {
                Program.Log?.Invoke(null, "SplashScreen Button: exit - pressed");
                form.Close();
            };

            Button[] menu = { play, records, exit };
            form.Controls.AddRange(menu);


        }



        private static void Form_ShootKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) MainGame.State.CurrentScene.Bullets.Add((MainGame.State.Player1.ControlledObject as Ship).Shoot());
        }
        private static void Form_MoveKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) (MainGame.State.Player1.ControlledObject as Ship).MoveUp();
            if (e.KeyCode == Keys.Down) (MainGame.State.Player1.ControlledObject as Ship).MoveDown();
        }
    }
}
