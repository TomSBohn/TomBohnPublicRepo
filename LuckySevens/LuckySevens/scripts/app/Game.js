$(document).ready(function() {
    $('#playGame')
        .on('click',
            function() {
                var player = {
                    StartingBet: $("#amount").val(),
                    TimesRolled: 0,
                    MaxWinnings: 0,
                    MaxWinningsRolled: 0
                };

                var currentWinnings = player.StartingBet;
                player.MaxWinnings = currentWinnings;

                do {
                    var die1 = Math.floor(Math.random() * 10 % 6 + 1);
                    var die2 = Math.floor(Math.random() * 10 % 6 + 1);

                    var sum = die1 + die2;

                    player.TimesRolled++;

                    if (sum == 7) {
                        currentWinnings += 4;
                        if (player.MaxWinnings < currentWinnings) {
                            player.MaxWinnings = currentWinnings;
                            player.MaxWinningsRolled = player.TimesRolled;
                        }
                    } else {
                        currentWinnings -= 1;
                    }


                } while (currentWinnings > 0);

                $("#StartingBet").val(player.StartingBet);
                $('#TimesRolled').val(player.TimesRolled);
                $('#MaxWinnings').val(player.MaxWinnings);
                $('#MaxWinningsRolled').val(player.MaxWinningsRolled);


                $('#resultsTable').show();
            });

    $('#playAgain').on('click', function () {
        $("#StartingBet").val('');
        $('#TimesRolled').val('');
        $('#MaxWinnings').val('');
        $('#MaxWinningsRolled').val('');

        $('#resultsTable').hide();
    });

    $('#resultsTable').hide();
});