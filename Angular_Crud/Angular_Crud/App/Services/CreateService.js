angular.module('myApp').service("CreateService", function ($http) {
    
    this.AddNewStudent = function (param) {
         
        return $http.post("Student/AddStudent",param);
    };

    this.GetNewStates = function () {
         
        return $http.get("Student/GetStates");
    };

    this.GetNewCitys = function () {
         
        return $http.get("Student/GetCitys");
    };
});