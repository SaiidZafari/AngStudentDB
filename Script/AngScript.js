/// <reference path="../scripts/angular.js" />

var myApp = angular.module("myModule", []);

myApp.controller("messageCont", function ($scope) {
    $scope.SaiidSay = "Angular is Working!";
});

myApp.controller("stuCont", function ($scope, $http) {
    $http.get("StudWebService.asmx/GetStudents").then(function (response) {
        $scope.students = response.data;
    });
    //$anchorScroll();
});

//, $location