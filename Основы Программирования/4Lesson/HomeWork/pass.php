<!DOCTYPE html>
<html lang="ru">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Личный сайт студента</title>
    <link rel="stylesheet" href="Style.css">
    <script type="text/javascript">
        //HelpFunctions
        function readInt() {
            var num = +document.getElementById("userAnswer").value;
            if (isNaN(num))
                alert("Пожалуйста введите число!");
            return num;
        }

        function write(id, text) {
            document.getElementById(id).innerHTML = text;
        }

        function visible(id) {
            document.getElementById(id).style.visibility = "visible";
        }

        function getRandomNumber(max) {
            return Math.round(Math.random() * max);
        }

        //PassGenerator
        var latLetters = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        var numbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];
        function generate() {
            var str = "";
            var strLength = readInt();
            var rand = 0;
            if (!isNaN(strLength)) {
                for (let index = 0; index < strLength; index++) {
                    rand = getRandomNumber(2);
                    if (rand == 0) {
                        str += latLetters[getRandomNumber(latLetters.length - 1)].toLowerCase();
                    } else if (rand == 1) {
                        str += latLetters[getRandomNumber(latLetters.length - 1)];
                    } else if (rand == 2) {
                        str += numbers[getRandomNumber(numbers.length - 1)];
                    }
                }
                visible("passGen");
                write("pass", str);
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
                    <h1>Генератор паролей</h1>
                    <div class="box">
                        <p id="info">Укажите в текстовом поле длину желаемого пароля, состоящий из латинских букв и
                            цифр.</p>
                        <input type="text" id="userAnswer">
                        <div id="passGen" style="visibility: hidden">
                            <p><b>Ваш пароль:</b></p>
                            <p id="pass"></p>
                        </div>
                        <br>
                        <a href="#" onClick="generate();" id="button">Сгенерировать</a>
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