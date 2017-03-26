(function () {
    "use strict";
    var taskIndexController = function ($scope, taskService) {

        $scope.title = null;
        $scope.tasks = null;

        $scope.readTasks = function () {
            $scope.title = null;
            taskService.readTasks().then(function (response) {
                $scope.tasks = response.data.tasks;
            }, function () {
                console.log("readTasks failed");
            });
        };

        $scope.createTask = function () {
            var task = { title: $scope.title };
            taskService.createTask(task).then(function (data) {
                $scope.readTasks();
            }, function () {
                console.log("createTask failed");
            });
        };

        $scope.updateTask = function (task) {
            taskService.updateTask(task).then(function (data) {
                $scope.readTasks();
            }, function () {
                console.log("updateTask failed");
            });
        };

        $scope.deleteTask = function (task) {
            taskService.deleteTask(task).then(function (data) {
                $scope.readTasks();
            }, function () {
                console.log("deleteTask failed");
            });
        };

        $scope.readTasks();
    };

    taskIndexController.$inject = ["$scope", "taskService"];
    angular.module("taskListApp")
        .controller("taskIndexController", taskIndexController);
})();