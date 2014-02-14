var myApp = angular.module('myApp', []);

myApp.controller('mainController', ['$scope', function ($scope) {

    var _questionId =  parseInt(document.getElementById('url').value);
    $scope.answers = [];
    $scope.countdown = 180;
    $scope.init = function() {
        console.log("Initializing");
        var poll = $.connection.poll;

        poll.client.castVote = function (name, questionId, option) {
            if (questionId != _questionId) 
                return;

            $scope.answers.push({ name: name, val: option });
            $scope.$apply();
        };

        $.connection.hub.start().done(function () {
        });

        timer = setInterval(function () {
            $scope.countdown = $scope.countdown - 1;
            $scope.$apply();
        }, 1000);
    }
}]);
