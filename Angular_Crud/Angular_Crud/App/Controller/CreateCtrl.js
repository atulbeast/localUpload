angular.module('myApp').controller('CreateCtrl', function ($scope, $http, $routeParams, $location, toaster, Upload, CreateService, $timeout) {

    $scope.States = [];
    $scope.Citys = [];
   
    toaster.pop({
        type: 'success',
        title: 'Title text',
        body: 'Data Save Succesfully!',
        timeout: 10000
    });

    // Adding New student record  

    //$scope.upload = function (file) {
      
    //};


    $scope.savedata = function (Student) {
      
        Upload.upload({
            url: 'Student/Post',
            data: { file: $scope.files}
        }).then(function (resp) {
            debugger
            Student.LogoUrl = resp.data;
            CreateService.AddNewStudent(Student).success(function (result) {

                if (result == 1) {
                 //   toaster.pop('success', 'Notification', 'Saved Successfully.', 2000);
                    toaster.pop('success', 'Notification', 'Saved Successfully...Redirecting To Home', 4000);
                    $timeout(function () {
                        // Redirecting you to List Page
                        $location.path('/');
                    }, 3000);
                  
                    }
                else {
                    toaster.pop('danger', 'Notification', 'Something Went Wrong');
                }
              
            }, function () {
                alert('Error in adding record');
            });
            console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
        }, function (resp) {
            console.log('Error status: ' + resp.status);
        }, function (evt) {
            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
            console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
        });




     
       
       
    }

    $scope.resetForm = function () {
        
        $scope.Student = {}
    };

    //Geting States from Data base
    $scope.GetStates = function () {
      
        CreateService.GetNewStates().success(function (States) {
           
            $scope.States = States;
        });
    }

    $scope.GetStates();

    $scope.GetCitys = function () {
        // 
        CreateService.GetNewCitys().success(function (Cits) {
           
            $scope.Citys = Cits;
        });
    }

    $scope.GetCitys();


    //For Cascading dropdown
    $scope.getCity = function () {
        
        var selectedStateId = $scope.Student.State;
       
        $scope.CityList = Enumerable.From($scope.Citys).Where(function (x) { return x.SId == selectedStateId }).Select(function (x) { return x }).ToArray();
    }


    
});

