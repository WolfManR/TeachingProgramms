<!DOCTYPE html>
<html lang="ru">

<head>
    <meta charset="UTF-8">
    <title>Личный сайт студента</title>
    <link rel="stylesheet" href="Style.css">
</head>

<body>
    <div class="content">
        <?php include "menu.php";?>

        <h1>Личный сайт студента GeekBrains</h1>

        <div class="center">
            <img src="img/Wolf.jpg">
            <div class="box_text">
                <p><b>Добрый день</b>, можете называть меня <i>WolfManR</i>. Я совсем недавно начал программировать,
                    однако
                    уже
                    написал свой первый сайт.</p>

                <p>В этом мне помог IT-портал <a href="https://geekbrains.ru">GeekBrains</a></p>

                <p>На этом сайте вы сможете сыграть в несколько игр, которые я написал:<br>
                    <a href="#">Главная</a>
                    <a href="puzzle.html">Загадка</a>
                    <a href="#">Угадайка</a>
                </p>
            </div>
        </div>
    </div>

    <div class="footer">
        Copyright &copy; <?php echo date("Y");?> WolfManR
    </div>

</body>

</html>