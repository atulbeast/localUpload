angular.module('myApp').controller('StudentCtrl', function ($scope, $http, $routeParams, $location, $rootScope, toaster,StudentService) {
    
  //  GetStudentList();
    $scope.Student = [];
    $scope.Sizelist = [3, 5, 10, 20];
    debugger
    $scope.Screen = [];
    $scope.Screen.isAdvanceOpen = false;
    $scope.openscreenshot = function () {

        $scope.Screen.isAdvanceOpen = true;
    }
       
    $scope.cancel = function () {

        if ($scope.Screen.advanceApi) $scope.Screen.advanceApi.cancel();
    };
        $scope.download = function () {
            if ($scope.Screen.advanceApi) $scope.Screen.advanceApi.download();
        }




    toaster.pop({
        type: 'error',
        title: 'Title text',
        body: 'Body text',
        timeout: 50000
    });
    $scope.changeSize = function ()
    {
        toaster.pop('info', "Page Size Changed", "" + $scope.GridCurrentPageSetting.selectedPageSize);
        StudSearch();

    }
   
    //Delete Student Record
    $scope.deleteStudent = function (Id) {
        debugger;
        var retval = StudentService.deleteStudent(Id).success(function (msg) {
           

            $location.path('/');
        }).error(function () {
            alert('Oops! something went wrong.');
        });
        toaster.pop('error', "", "Data Deleted Succesfully!", 10000);
    }

    //For Update Student
    $scope.UpdateStudent = function (student) {
          
        $rootScope.editData = student;
    }

    $scope.searchField = [];
    $scope.GridCurrentPageSetting = [];
    $scope.GridCurrentPageSetting.selectedPageSize = 3;
  
    $scope.GridCurrentPageSetting.currentPage=1
    StudSearch();


    $scope.Searchbtn = function () {
         
        StudSearch();
    }

    //For Searching and pagination
   function StudSearch () {
       //debugger;
        var params = {
            ID: $scope.searchField.studentID == undefined ? 0 : $scope.searchField.studentID,
            FirstName: $scope.searchField.studentFName == undefined ? null : $scope.searchField.studentFName,
            PageSize: $scope.GridCurrentPageSetting.selectedPageSize,
            CurrentPage: $scope.GridCurrentPageSetting.currentPage
          
        }
       //Gets Data And Page Info
        StudentService.StudentSearch(params).success(function(data) {
              //debugger
            $scope.GridCurrentPageSetting.pageSizes = [];
            $scope.Student = data.StudentModelList;
            $scope.GridCurrentPageSetting.totalRecords = data.TotalRec.TotalRecords;
            $scope.GridCurrentPageSetting.totalPages = Math.ceil(data.TotalRec.TotalRecords / $scope.GridCurrentPageSetting.selectedPageSize);
           
            
        });
    }
   

    $scope.PageChanged = function (pageNo) {
         //debugger
        $scope.GridCurrentPageSetting.currentPage = pageNo;
        StudSearch();
    };

    $scope.PageSizeChanged = function (selectedPageSize) {
         //debugger
        $scope.GridCurrentPageSetting.currentPage = 1;
        $scope.GridCurrentPageSetting.selectedPageSize = selectedPageSize;
        StudSearch();
    };
  
});

