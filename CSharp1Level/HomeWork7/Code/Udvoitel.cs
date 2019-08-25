using System;
using System.Collections.Generic;

namespace HomeWork7.Code
{
    public class Udvoitel
    {
        readonly Random rand = new Random();
        int playerSteps = 0;
        int stepsToFinish;
        Stack<StepType> stepTypes = new Stack<StepType>();

        public GameState State
        {
            get
            {
                if (Current < Number & playerSteps<=stepsToFinish) return GameState.Play;
                else if (Current > Number || playerSteps > stepsToFinish) return GameState.Loose;
                else return GameState.Win;
            }
        }
        public int Current { get; private set; } = 1;
        public int Number { get; private set; }
        public int StepsToFinish { get => stepsToFinish - playerSteps; }

        public event EventHandler<GameStateEventArgs> Won;
        public event EventHandler<GameStateEventArgs> Lost;

        public Udvoitel()
        {

        }
        
        void CheckState()
        {
            GameState state = State;
            switch (state)
            {
                case GameState.Win:
                    Won?.Invoke(this, new GameStateEventArgs($"Вы выйграли\nВы сделали ходов {playerSteps} из {stepsToFinish}"));
                    return;
                case GameState.Loose:
                    Lost?.Invoke(this, new GameStateEventArgs($"Вы проиграли\nВы сделали ходов {playerSteps} из {stepsToFinish}"));
                    return;
                case GameState.Play:
                    return;
            }
        }
        public void Add()
        {
            Current++;
            playerSteps++;
            stepTypes.Push(StepType.Add);
            CheckState();
        }
        public void Multi()
        {
            Current *= 2;
            playerSteps++;
            stepTypes.Push(StepType.Multy);
            CheckState();
        }

        public void Reset()
        {
            Current = 1;
            playerSteps = 0;
            stepTypes.Clear();
        }
        public void NewGame()
        {
            Current = 1;
            playerSteps = 0;
            stepTypes.Clear();
            Number = rand.Next(2, 101);
            int CalcSteps()
            {
                int toFinish = Number;
                int steps = 0;
                while (toFinish / 2 != 0)
                {
                    steps++;
                    if (toFinish % 2 != 0)steps += toFinish % 2;
                    toFinish /= 2;
                }
                return steps;
            }
            stepsToFinish = CalcSteps();
        }
        public void BackStep()
        {
            if (stepTypes.Count == 0) return;
            switch (stepTypes.Pop())
            {
                case StepType.Add:
                    Current--;
                    break;
                case StepType.Multy:
                    Current /= 2;
                    break;
            }
            playerSteps--;
        }
        enum StepType
        {
            Add, Multy
        }
    }
}
