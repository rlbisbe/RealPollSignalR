var myApp = angular.module('myApp', []);

myApp.controller('mainController', ['$scope', function ($scope) {

    $scope.answers = [];
    $scope.countdown = 180;

    $scope.init = function() {
        console.log("Initing");
        var poll = $.connection.poll;

        poll.client.castVote = function (option) {
            $scope.answers.push({val: option});
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
