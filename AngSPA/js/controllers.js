(function () {
    'use strict';

    /* Controllers */
    var Controllers = angular.module('itemsControllers', []);
    
    Controllers.controller('TestListCtrl', ['$scope', '$http', 
        function ($scope, $http) {
            // Note: Dictionaries *are* objects
            $scope.tests = [ {id : 1,
                              desc : "Lorem ipsum dolor sit amet.",
                              name : "Test 1",
                              pass : true},
                             {id : 2,
                              desc : "The quick brown fox jumps over the lazy dog.",
                              name : "Test 2",
                              pass : false},
                             {id : 3,
                              dec : "Jackdaws love my big sphinx of quartz.",
                              name : "Test 3",
                              pass: false}]; 
            $scope.author = 'idk';
        }]);

    Controllers.controller('TestDetailCtrl', ['$scope', '$http', 
        function ($scope, $http) {
            // Note: Dictionaries *are* objects
            $scope.tests = [ {id : 1,
                              desc : "Lorem ipsum dolor sit amet.",
                              name : "Test 1",
                              pass : true},
                             {id : 2,
                              desc : "The quick brown fox jumps over the lazy dog.",
                              name : "Test 2",
                              pass : false},
                             {id : 3,
                              dec : "Jackdaws love my big sphinx of quartz.",
                              name : "Test 3",
                              pass: false}]; 
            $scope.author = 'idk';
        }]);
}())
