angular.module('myApp').service("StudentService", function ($http, ajaxService) {
    //get All Eployee  


      this.getAllStudents = function () {
         
        return $http.get("Student/GetStudentList");  
    };

    //Delete Student
      this.deleteStudent = function (Id) {
           
          return $http.post('Student/DeleteStudent/' + Id)
      }

      this.StudentSearch = function (params) {
          
          return $http.post("Student/GetStudentList", params);
      };
});