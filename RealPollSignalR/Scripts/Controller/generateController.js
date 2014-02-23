var myApp = angular.module('myApp', []);

myApp.controller('generateController', ['$scope', function ($scope) {

    $scope.answersCount;
    $scope.answers = [];

    $scope.setAnswers = function ()
    {
        var count = parseInt($scope.answersCount);
        console.log(count);
        console.log($scope.answersCount);

        $scope.answers = [];
        for (var i = 0; i < count; i++) {
            $scope.answers.push({ 
                id: "Answers_" + i + "__AnswerText",
                cbId: "Answers_" + i + "__IsCorrect",
                name: "Answers[" + i + "].AnswerText",
                cbName: "Answers[" + i + "].IsCorrect"
            });
            $scope.$apply();
        }
    };
}]);
