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

        public event EventHandler<GameStateEventArgs> Winned;
        public event EventHandler<GameStateEventArgs> Loosed;
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
            if (number != this.number & tryes>playersSteps) return;
            else if (number != this.number & tryes <= playersSteps) Loosed?.Invoke(this, new GameStateEventArgs($"Вы проиграли!"));
            else Winned?.Invoke(this, new GameStateEventArgs($"Вы выйграли!"));
        }
    }
}
