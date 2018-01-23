angular.module('myApp').service("EditService",['$http',function($http){

    this.UpdateStudent = function (param) {
          
        return $http.post("Student/UpdateStudent", param);
    };

    this.GetNewStates = function () {
          
        return $http.get("Student/GetStates");
    };

    this.GetNewCitys = function () {
      
        return $http.get("Student/GetCitys");
    };


}])  
