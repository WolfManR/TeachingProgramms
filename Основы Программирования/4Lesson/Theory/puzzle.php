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
                        if (isset($_GET["userAnswer1"])&& isset($_GET["userAnswer2"])&&isset($_GET["userAnswer3"])) {
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

                            echo "Вы угадали " . $score . " загадок";
                        }
                        ?>
                        <form method="GET">
                            <p>Что можно увидеть с закрытыми глазами?</p>
                            <input type="text" name="userAnswer1">
                            <p>Что можно увидеть с закрытыми глазами?</p>
                            <input type="text" name="userAnswer2">
                            <p>Что можно увидеть с закрытыми глазами?</p>
                            <input type="text" name="userAnswer3">
                            <br>
                            <input type="submit" value="Ответить"name>
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