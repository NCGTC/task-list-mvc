(function () {
    "use strict";
    var taskService = function ($http, $q) {

        var baseUrl = "/Tasks/";

        var post = function (action, data) {
            return $http.post(baseUrl + action, data);
        };

        var readTasks = function () {
            return post("Read", null);
        };

        var createTask = function (data) {
            return post("Create", data);
        };

        var updateTask = function (data) {
            return post("Update", { id: data.id, isDone: data.isDone });
        };

        var deleteTask = function (data) {
            return post("Delete", { id: data.id });
        };

        return {
            readTasks: readTasks,
            createTask: createTask,
            updateTask: updateTask,
            deleteTask: deleteTask
        }
    };

    taskService.$inject = ["$http", "$q"];
    angular.module("taskListApp")
        .factory("taskService", taskService);
})();