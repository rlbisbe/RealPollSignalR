function AnswerList() {

    var __self = this;

    this.answers = [];

    this.count = 1;

    this.isModelValid = function ()
    {
        var answer = __self.count;
        if (isNaN(answer)) {
            __self.errorMessage = "The value is not a number";
            return false;
        }
        var count = parseInt(answer);
        if (count > 10 || count < 1) {
            __self.errorMessage = "The number of answers must be greater or equal than 1 and smaller or equal than 10";
            return false;
        }

        __self.errorMessage = "";
        return true;
    }

    this.errorMessage = "";
}