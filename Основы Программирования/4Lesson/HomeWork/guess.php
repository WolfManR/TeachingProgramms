<!DOCTYPE html>
<html lang="ru">

<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Личный сайт студента</title>
    <link rel="stylesheet" href="Style.css">
    <script type="text/javascript">
        var answer = parseInt(Math.random() * 100);
        var tryCount = 0;
        var maxTryCount = 3;

        function readInt() {
            return +document.getElementById("userAnswer").value;
        }

        function write(text) {
            document.getElementById("info").innerHTML = text;
        }

        function hide(id) {
            document.getElementById(id).style.display = "none";
        }

        function guess() {
            tryCount++;

            var userAnswer = readInt();
            if (userAnswer == answer) {
                write("<b>Поздравляю, вы угадали!</b>");
                hide("button");
                hide("userAnswer");
            } else if (tryCount >= maxTryCount) {
                write("Вы проиграли<br>Правильный ответ: " + answer);
                hide("button");
                hide("userAnswer");
            } else if (userAnswer > answer) {
                write("Вы ввели слишком большое число<br>Попробуйте еще раз. Введите число от 1 до 100");
            } else if (userAnswer < answer) {
                write("Вы ввели слишком маленькое число<br>Попробуйте еще раз. Введите число от 1 до 100");
            }
        }
    </script>
</head>

<body>
    <div class="content">
        <?php include "menu.php";?>
        <div class="contentWrap">
            <div class="content">
                <div class="center">
                    <h1>Игра Угадайка</h1>
                    <div class="box">
                        <p id="info">Угадайте число от 0 до 100</p>
                        <input type="text" id="userAnswer">
                        <br>
                        <a href="#" onClick="guess();" id="button">Начать</a>
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