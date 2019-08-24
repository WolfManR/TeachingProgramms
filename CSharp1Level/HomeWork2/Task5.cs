﻿using System;
using HomeWorkLib;
using HWConsoleLibrary;

namespace HomeWork2
{
    public class Task5 : HomeWorkTask
    {
//        Индекс массы тела
//        Соответствие между массой человека и его ростом 
//              16 и менее            Выраженный дефицит массы тела 
//              16—18,5               Недостаточная(дефицит) масса тела 
//              18,5—24,99            Норма 
//              25—30                 Избыточная масса тела(предожирение)
//              30—35                 Ожирение 
//              35—40                 Ожирение резкое 
//              40 и более            Очень резкое ожирение
       
        public override string Title => "Индекс массы тела";

        public override int TaskNumber => 5;

        public override string ToDo => "а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы " +
                                       "\nи сообщает, нужно ли человеку похудеть, набрать вес или все в норме;" +
                                       "\nб) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.";

        public override void Work()
        {
            Console.Write("Пожалуйста введите вес в кг измеряемого человека ");
            int weight=Converters.ReadInt();
            Console.Write("Пожалуйста введите рост в метрах измеряемого человека ");
            double height=double.Parse(Console.ReadLine());
            double imt = Helper.IMT(weight,height);
            int WeightToNormal;
            if (imt >= 18.5 & imt <= 24.99) Console.WriteLine("\nВаш индекс массы тела в норме");
            else if (imt >= 25)
            {
                WeightToNormal = weight - WeightFromIMT(24.99, height);
                Console.WriteLine($"\nУ вас избыточная масса тела, вам нужно похудеть на {WeightToNormal}кг");
            }
            else
            {
                WeightToNormal =  WeightFromIMT(18.5, height)-weight;
                Console.WriteLine($"\nУ вас дефицит массы тела, вам нужно набрать {WeightToNormal}кг");
            }
        }

        int WeightFromIMT(double IMT,double height) => Convert.ToInt32(IMT*height*height);
    }
}