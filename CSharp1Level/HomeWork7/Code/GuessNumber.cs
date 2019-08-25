using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7.Code
{
    public class GuessNumber
    {
        Random rand = new Random();
        int tryes = 3;
        int number;
        int playersSteps = 0;
        public int TryesLeft { get => tryes - playersSteps; }

        public event EventHandler<GameStateEventArgs> Won;
        public event EventHandler<GameStateEventArgs> Lost;
        public event EventHandler<GameStateEventArgs> HowClose;
        public GuessNumber()
        {

        }
        public GuessNumber(int tryes)
        {
            this.tryes = tryes;
        }
        public void NewGame()
        {
            number = rand.Next(1, 100);
            playersSteps = 0;
        }

        public void CheckNumber(int number)
        {
            playersSteps++;
            if (number != this.number & tryes > playersSteps)
            {
                if (number > this.number) HowClose?.Invoke(this, new GameStateEventArgs($"Ваше число больше загаданного"));
                else HowClose?.Invoke(this, new GameStateEventArgs($"Ваше число меньше загаданного"));
            }
            else if (number != this.number & tryes <= playersSteps) Lost?.Invoke(this, new GameStateEventArgs($"Вы проиграли!\nЗагаданное число было {this.number}"));
            else Won?.Invoke(this, new GameStateEventArgs($"Вы выйграли!"));
        }
    }
}
