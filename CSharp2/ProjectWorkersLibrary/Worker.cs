﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWorkersLibrary
{
    /*  Lesson 2 Part 1
     * 1. Построить три класса (базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
     * а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы. Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
     * б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
     * в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
     * г) *Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
     */

    public abstract class Worker:Person
    {
        public abstract double AverageMonthySalary();
    }
}
