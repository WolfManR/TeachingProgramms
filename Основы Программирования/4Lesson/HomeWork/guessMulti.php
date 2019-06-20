<!DOCTYPE html>
<html lang="ru">

<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Личный сайт студента</title>
    <link rel="stylesheet" href="Style.css">
    <script type="text/javascript">
        //data
        var answer = 0;
        var firstPlayerWin = 0;
        var secondPlayerWin = 0;
        var playerTurn = 1;
        var defaultMsg = "Угадайте число от 0 до 100";

        //HelpFunctions
        function readInt() {
            return +document.getElementById("userAnswer").value;
        }

        function write(id, text) {
            document.getElementById(id).innerHTML = text;
        }

        function visible(id) {
            id.forEach(element => {
                document.getElementById(element).style.visibility = "visible";
            });
        }

        function hide(id) {
            id.forEach(element => {
                document.getElementById(element).style.visibility = "hidden";
            });
        }
        
        //MainFunctions
        function startGame() {
            hide(["btnStartGame"]);
            visible(["info", "userAnswer", "button", "Counter", "Reset"]);
            answer = parseInt(Math.random() * 100);
            write("info", defaultMsg + "<br>Ход первого игрока");
        }

        function reset() {
            visible(["btnStartGame"]);
            hide(["info", "userAnswer", "button", "Counter", "Reset"]);
            answer = parseInt(Math.random() * 100);
            write("info", defaultMsg + "<br>Ход первого игрока");
            write("firstCounter", "Первый игрок: ");
            write("secondCounter", "Второй игрок: ");
            document.getElementById("userAnswer").value = "";
            firstPlayerWin = 0;
            secondPlayerWin = 0;
            playerTurn = 1;
        }
        
        function guess() {
            var userAnswer = readInt();
            if (playerTurn == 1) {
                if (userAnswer == answer)
                    firstPlayerWin++;
                answer = parseInt(Math.random() * 100);
                write("firstCounter", "Первый игрок: " + firstPlayerWin);
                write("info", defaultMsg + "<br>Ход второго игрока");
                playerTurn = 2;
            } else if (playerTurn == 2) {
                if (userAnswer == answer)
                    secondPlayerWin++;
                answer = parseInt(Math.random() * 100);
                write("secondCounter", "Второй игрок: " + secondPlayerWin);
                write("info", defaultMsg + "<br>Ход первого игрока");
                playerTurn = 1;
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
                    <h1>Игра Угадайка для Двоих игроков</h1>
                    <div class="box">

                        <p id="info" style="visibility: hidden"></p>
                        <input type="text" id="userAnswer" style="visibility: hidden">
                        <br>
                        <a href="#" onClick="guess();" id="button" style="visibility: hidden">Ответить</a>
                        <a href="#" onClick="startGame();" id="btnStartGame" class="start">Начать игру</a>
                        <br><br><br>
                        <div id="Counter" style="visibility: hidden">
                            <p style="margin-left: 40px;"><b>Счёт</b></p>
                            <p id="firstCounter">Первый игрок: </p>
                            <p id="secondCounter">Второй игрок: </p>
                        </div>
                        <br><br><br>
                        <a href="#" onClick="reset();" id="Reset" style="visibility: hidden">Начать с начала</a>
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