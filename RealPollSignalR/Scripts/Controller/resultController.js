var myApp = angular.module('myApp', ["angles"]);

String.prototype.toHHMMSS = function () {
    var sec_num = parseInt(this, 10); // don't forget the second param
    var hours = Math.floor(sec_num / 3600);
    var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
    var seconds = sec_num - (hours * 3600) - (minutes * 60);

    if (hours < 10) { hours = "0" + hours; }
    if (minutes < 10) { minutes = "0" + minutes; }
    if (seconds < 10) { seconds = "0" + seconds; }
    var time = hours + ':' + minutes + ':' + seconds;
    return time;
}

myApp.controller('resultController', ['$scope', "$location", function ($scope, $location) {

    var _questionId = parseInt(document.getElementById('url').value);

    $scope.myChartOptions = {
        //Boolean - Whether we should show a stroke on each segment
        segmentShowStroke: true,

        //String - The colour of each segment stroke
        segmentStrokeColor: "#fff",

        //Number - The width of each segment stroke
        segmentStrokeWidth: 4,

        //The percentage of the chart that we cut out of the middle.
        percentageInnerCutout: 50,

        //Boolean - Whether we should animate the chart
        animation: false,

        //Number - Amount of animation steps
        animationSteps: 100,

        //String - Animation easing effect
        animationEasing: "easeOutBounce",

        //Boolean - Whether we animate the rotation of the Doughnut
        animateRotate: true,

        //Boolean - Whether we animate scaling the Doughnut from the centre
        animateScale: false,

        //Function - Will fire on animation completion.
        onAnimationComplete: null
    };

    var colors = ["#F7464A", "#E2EAE9", "#D4CCC5", "#949FB1", "#4D5360"]
    $scope.myChartData = [];
    $scope.answers = [];
    $scope.countdownText = "180".toHHMMSS();
    $scope.countdown = 180;

    $scope.init = function () {
        var hash = parseInt($location.search().time);
        if (hash) {
            $scope.countdown = hash;
            $scope.countdownText = $scope.countdown.toString().toHHMMSS();
            console.log("Initializing with a countdown of " + $scope.countdown + " seconds");
        } else {
            console.log("Initializing with standard 180 seconds countdown");
        }

        var poll = $.connection.poll;

        poll.client.castVote = function (name, questionId, option) {
            if (questionId != _questionId) 
                return;

            $scope.answers.push({ name: name, val: option });
            var found = false;
            for (var i in $scope.myChartData) {
                if ($scope.myChartData[i].option == option) {
                    $scope.myChartData[i].value++;
                    found = true;
                    break;
                }
            }
            if (found == false) {
                $scope.myChartData.push({
                    value: 1,
                    option: option,
                    color: colors[$scope.myChartData.length % colors.length]
                });
            }
            
            $scope.$apply();
        };

        $.connection.hub.start().done(function () {
        });

        timer = setInterval(function () {
            $scope.countdown = $scope.countdown - 1;
            $scope.countdownText = $scope.countdown.toString().toHHMMSS();
            $scope.$apply();
        }, 1000);
    }
}]);
