var myApp = angular.module('myApp', []);

myApp.controller('generateController', ['$scope', function ($scope) {

    $scope.answersCount;
    $scope.answers = [];


    function addAnswers(toAdd)
    {
        for (var i = 0; i < toAdd; i++) {
            $scope.answers.push({
                id: "Answers_" + i + "__AnswerText",
                cbId: "Answers_" + i + "__IsCorrect",
                name: "Answers[" + i + "].AnswerText",
                cbName: "Answers[" + i + "].IsCorrect"
            });
            $scope.$apply();
        }
    }

    function removeAnswers(toRemove) {
        for (var i = 0; i < toRemove; i++) {
            $scope.answers.pop();
            $scope.$apply();
        }
    }

    $scope.setAnswers = function ()
    {
        var count = parseInt($scope.answersCount);
        var toModify = count - $scope.answers.length;

        if (toModify > 0) {
            addAnswers(toModify);
        }
        if (toModify < 0) {
            removeAnswers(toModify * -1);
        }
    };
}]);
