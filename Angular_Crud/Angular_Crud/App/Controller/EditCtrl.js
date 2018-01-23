angular.module('myApp').controller('EditCtrl', function ($scope, $http, $routeParams, $location, toaster, EditService, $rootScope) {
      
   
    $scope.selectedState = {};
    $scope.selectedCity = [];
    toaster.pop({
        type: 'success',
        title: 'Title text',
        body: 'Update Succesfully!',
        timeout: 10000
    });
    // Updating Records  
    $scope.updatedata = function (editStudent) {
        //  
        EditService.UpdateStudent(editStudent).success(function (result) {
           
            if (result == 1) {
               
                $location.path('/');
            }
            else {

            }
            toaster.pop('success', 'Notification', 'Update Successfully!', 10000);
        }, function () {
            alert('Error in adding record');
        });
       
    }
    //Reset Student Record
    $scope.resetForm = function () {
          
        $scope.Student = {}
    };

   

    //Geting States from Data base
    $scope.GetStates = function () {
    
        EditService.GetNewStates().success(function (States) {
           
               $scope.editStudent = $rootScope.editData;
           $scope.States = States;
           if ($scope.States.length > 0) {
             //  debugger;
               for (i = 0; i <= $scope.States.length; i++) {
                   if ($scope.States[i].SName == $scope.editStudent.SName) {
                       $scope.selectedState = $scope.States[i];
                       return;
                   }
               }
           }
        });
    }

    $scope.GetStates();
   
   
    //Get City from Database
     $scope.GetCitys = function () {
         debugger;
        EditService.GetNewCitys().success(function (citys) {
           debugger;
            $scope.editStudent = $rootScope.editData;
            $scope.Citys = citys;
            if ($scope.Citys.length > 0) {
                debugger;
                for (i = 0; i <= $scope.Citys.length; i++) {
                    if ($scope.Citys[i].Name === $scope.editStudent.CityName) {
                        $scope.selectedCity = $scope.Citys[i].Id;
                        return;
                    }
                }
            }
        });
    }

    $scope.GetCitys();

    //For Cascading dropdown
    $scope.getCity = function () {
        
       
        debugger;
        var selectedStateId = $scope.selectedState.ID;
        $scope.Citys = Enumerable.From($scope.Citys).Where(function (x) { return x.SId == selectedStateId }).Select(function (x) { return x }).ToArray();
        
    }



    
});