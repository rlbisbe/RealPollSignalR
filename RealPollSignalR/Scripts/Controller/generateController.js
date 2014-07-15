var myApp = angular.module('myApp', []);

myApp.controller('generateController', ['$scope', function ($scope) {

    $scope.answerList = new AnswerList();

    function addAnswers(base, toAdd)
    {
        for (var i = 0; i < toAdd; i++) {
            var index = base + i;
            $scope.answerList.answers.push({
                id: "Answers_" + index + "__AnswerText",
                cbId: "Answers_" + index + "__IsCorrect",
                name: "Answers[" + index + "].AnswerText",
                cbName: "Answers[" + index + "].IsCorrect"
            });
        }
    }

    function removeAnswers(toRemove) {
        for (var i = 0; i < toRemove; i++) {
            $scope.answerList.answers.pop();
        }
    }

    $scope.setAnswers = function ()
    {
        if ($scope.answerList.isModelValid()) {
            var toModify = $scope.answerList.count - $scope.answerList.answers.length;

            if (toModify > 0) {
                addAnswers($scope.answerList.answers.length, toModify);
            }
            if (toModify < 0) {
                removeAnswers(toModify * -1);
            }
        }
    };
}]);
