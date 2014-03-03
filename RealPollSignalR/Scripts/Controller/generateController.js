var myApp = angular.module('myApp', []);

myApp.controller('generateController', ['$scope', function ($scope) {

    $scope.answersCount;
    $scope.answers = [];


    function addAnswers(base, toAdd)
    {
        for (var i = 0; i < toAdd; i++) {
            var index = base + i;
            $scope.answers.push({
                id: "Answers_" + index + "__AnswerText",
                cbId: "Answers_" + index + "__IsCorrect",
                name: "Answers[" + index + "].AnswerText",
                cbName: "Answers[" + index + "].IsCorrect"
            });
        }
    }

    function removeAnswers(toRemove) {
        for (var i = 0; i < toRemove; i++) {
            $scope.answers.pop();
        }
    }

    $scope.setAnswers = function ()
    {
        var count = parseInt($scope.answersCount);
        var toModify = count - $scope.answers.length;

        if (toModify > 0) {
            addAnswers($scope.answers.length, toModify);
        }
        if (toModify < 0) {
            removeAnswers(toModify * -1);
        }
    };
}]);
