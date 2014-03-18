$(document).ready(function () {
    //called when key is pressed in textbox
    $("#answerCount").keypress(function (e) {
        
        //if the letter is not digit then display error and don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //display error message

            $("#errmsg").html("Digits Only").show().fadeOut("slow");
            return false;
        }
    });
    $("#answerCount").keyup(function (e) {
        if (!(e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57))) {
            var num = $("#answerCount").val();
            if (num > 10 || num == 0) {
                $("#errmsg").html("The value must be between 1 and 10").show().fadeOut("slow");
                $("#answerCount").val('');
                $("#answerCount").val('');
                return false;
            }
        }
    });
});