'use strict';

var apiLink = "http://67.211.223.28/JavaTestApi/api";
var globalTimeout = 50000;

angular.module('myApp.view1', ['ngRoute', 'ngResource'])

  .config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/view1', {
      templateUrl: 'view1/view1.html',
      controller: 'View1Ctrl'
    });
  }])

  .controller('View1Ctrl', ['$scope', '$log', 'crudFactory', function ($scope, $log, crudFactory) {
    // $scope.persons = [{ "UserCode": "1", "FirstName": "Simon", "LastName": "Aluvala", "JobTitle": "SE" }, { "UserCode": "2", "FirstName": "Manju", "LastName": "Baireddy", "JobTitle": "QA" }];
    $scope.persons = crudFactory.listPersons.query();
    $scope.populatePerson = function (person) {
      // $log.log($index);
      $scope.UserCode = person.UserCode;
      $scope.FirstName = person.FirstName;
      $scope.LastName = person.LastName;
      $scope.JobTitle = person.JobTitle;
      $scope.index = $scope.persons.indexOf(person);
      // console.log($scope.index);
    };
    $scope.updatePerson = function () {
      var person = {
        "UserCode": $scope.UserCode, "FirstName": $scope.FirstName, "LastName": $scope.LastName, "JobTitle": $scope.JobTitle
      };
      // alert(JSON.stringify(person));
      $log.log(JSON.stringify($scope.persons[$scope.index]));
      $log.log(JSON.stringify(person));
      var areEqual = ((JSON.stringify($scope.persons[$scope.index]) === (JSON.stringify(person))));
      if (!areEqual) {
        $scope.persons[$scope.index] = person;
        crudFactory.updatePerson.update({ UserCode: $scope.UserCode }, person, function (response) {
          $log.log("Updated Successfully.");
        });
        angular.element('#updatePerson').attr('data-dismiss', 'modal');
      }
    }
  }])
  .factory('crudFactory', function ($resource, $rootScope) {
    return {
      listPersons: $resource(apiLink + '/User', {}, {
        query: { method: 'GET', params: {}, isArray: true, timeout: globalTimeout, ignoreLoadingBar: true }
      }),
      updatePerson: $resource(apiLink + '/User', { UserCode: '@UserCode' }, {
        'update': { method: 'PUT', params: {}, isArray: false, timeout: globalTimeout, ignoreLoadingBar: true }
      })
    };
  });