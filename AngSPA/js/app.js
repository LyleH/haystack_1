(function () {
    'use strict';

    var codeCoverageApp = angular.module('codeCoverageApp', [
      'ngRoute',
      'itemsControllers'
    ])
    .directive('links', function() {
      return {
          scope : {
              id : '=test_id'
          },
          link: function(scope, element, attrs) {
              if (scope.$last){
                  $(".nameContainer").click(function() {
                      alert('IT WORKZ');
                  });
              }
          }
      };
    });

    codeCoverageApp.config(['$routeProvider',
      function($routeProvider) {
        $routeProvider.
          when('/testview', {
            templateUrl: 'partials/testview.html',
            controller: 'TestListCtrl'
          }).
          when('/test/:itemId', {
            templateUrl: 'partials/test-detail.html',
            controller: 'TestDetailCtrl'
          }).
          when('/pollvote', {
            templateUrl: 'partials/pollvote.html',
            controller: 'PollListCtrl'
          }).
          otherwise({
            // TODO: Should redirect to 404
            redirectTo: '/testview'
          });
      }]);
}())
