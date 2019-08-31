namespace HomeWork8.Code
{
    //Класс для вопроса    
    public class Question
    {
        public string text { get; set; }//Текст вопроса
        public bool trueFalse { get; set; }//Правда или нет

        //Для сериализации должен быть пустой конструктор.
        public Question()
        {
        }
        public Question(string text, bool trueFalse)
        {
            this.text = text;
            this.trueFalse = trueFalse;
        }
    }
}
