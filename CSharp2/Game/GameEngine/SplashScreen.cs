using System.Drawing;
using System.Windows.Forms;

namespace GameProject
{
    static class SplashScreen
    {
        public static void Init(Form form)
        {
            form.BackgroundImage = Image.FromFile(@"Assets/BackGround1.jpg");
            StackPanel panel = new StackPanel();
            panel.Width = 200;
            panel.Height = 300;
            panel.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            panel.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            Button play = new Button();
        }
    }
}
