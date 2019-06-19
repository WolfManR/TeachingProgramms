<!DOCTYPE html>
<html lang="ru">

<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Личный сайт студента</title>
    <link rel="stylesheet" href="Style.css">
    
</head>

<body>
    <div class="content">
        <?php include "menu.php";?>

        <div class="contentWrap">
            <div class="content">
                <div class="center">
                    <h1>Игра в загадки</h1>
                    <div class="box">
                        <?php
                        if (isset($_GET["userAnswer1"])&& isset($_GET["userAnswer2"])&&isset($_GET["userAnswer3"])&&isset($_GET["userAnswer4"])&& isset($_GET["userAnswer5"])&&isset($_GET["userAnswer6"])) {
                            $userAnswer=$_GET["userAnswer1"];
                            $score=0;
                            if($userAnswer=="сон"||$userAnswer=="сноведение"){
                                $score++;
                            }

                            $userAnswer=$_GET["userAnswer2"];
                            if($userAnswer=="морской"){
                                $score++;
                            }

                            $userAnswer=$_GET["userAnswer3"];
                            if($userAnswer=="шахматный"||$userAnswer=="мёртвый"){
                                $score++;
                            }

                            $userAnswer=$_GET["userAnswer4"];
                            $score=0;
                            if($userAnswer=="утюг"){
                                $score++;
                            }

                            $userAnswer=$_GET["userAnswer5"];
                            if($userAnswer=="чайник"){
                                $score++;
                            }

                            $userAnswer=$_GET["userAnswer6"];
                            if($userAnswer=="год"){
                                $score++;
                            }
                            echo "Вы угадали " . $score . " загадок";
                            
                        }
                        ?>
                        <form method="GET">
                            <p>Что можно увидеть с закрытыми глазами?</p>
                            <input type="text" name="userAnswer1">
                            <p>Какой болезнью никто не болеет на суше?</p>
                            <input type="text" name="userAnswer2">
                            <p>Какой конь не ест овса?</p>
                            <input type="text" name="userAnswer3">
                            <br>
                            <p>В Полотняной стране<br>По реке Простыне<br>Плывет пароход<br>То назад, то вперед,<br>А за ним такая гладь —<br>Ни морщинки не видать.</p>
                            <input type="text" name="userAnswer4">
                            <p>В брюшке — баня,<br>В носу — решето,<br>Нос — хоботок,<br>На голове — пупок,<br>Всего одна рука<br>Без пальчиков,<br>И та — на спине Калачиком.</p>
                            <input type="text" name="userAnswer5">
                            <p>Стоит дуб,<br>В нем двенадцать гнезд,<br>В каждом гнезде<br>По четыре яйца,<br>В каждом яйце<br>По семи цыпленков.</p>
                            <input type="text" name="userAnswer6">
                            <br>
                            <input type="submit" value="Ответить">
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="footer">
        Copyright &copy; <?php echo date("Y");?> WolfManR
    </div>

</body>

</html>