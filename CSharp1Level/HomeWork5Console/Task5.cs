using HomeWorkLib;

namespace HomeWork5Console
{
    internal class Task5 : HomeWorkTask
    {
        public override string Title => "«Верю. Не верю»";

        public override int TaskNumber => 5;

        public override string ToDo => "**Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет. " +
                                       "\nНапример: «Шариковую ручку изобрели в древнем Египте», «Да». " +
                                       "\nКомпьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. " +
                                       "\nИгрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. " +
                                       "\nСписок вопросов ищите во вложении или воспользуйтесь интернетом.";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}