using HomeWorkLib;

namespace HWConsoleLibrary
{
    public static class Helper
    {
        //можно расширить возможно для обработки не только целочисленного положительного числа
        public static bool CheckStringNumber(string number)
        {
            char[] charNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool isNumber = true;

            for (int i = 0; isNumber && i < number.Length; i++)
            {
                int correctNumber = 0;
                for (int j = 0; isNumber && j < charNumbers.Length; j++)
                    if (number[i] == charNumbers[j])
                    {
                        correctNumber++;
                        break;
                    }
                if (correctNumber == 0) isNumber = false;
            }
            return isNumber;
        }
        public static double IMT(int weight, double height) => weight / (height * height);

        public static void WorkTasks(ITaskWork[] tasks)
        {
            for (int i = 0; i < tasks.Length; i++) tasks[i].Work();
        }
    }
}
