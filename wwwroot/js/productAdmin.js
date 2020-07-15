angular.module('myApp', ['ui.bootstrap', 'dataGrid', 'pagination'])
    .controller('myAppController', ['$scope', 'myAppFactory', '$filter', '$uibModal', '$log'
        , function ($scope, myAppFactory, $filter, $uibModal, $log) {

            $scope.gridOptions = {
                data: [],
                urlSync: true
            };

            myAppFactory.getData().then(function (responseData) {
                $scope.gridOptions.data = responseData.data;
            });

            $scope.exportToCsv = function (currentData) {
                var exportData = [];
                currentData.forEach(function (item) {
                    exportData.push({
                        'Code': item.code,
                        'Date Placed': $filter('date')(item.placed, 'shortDate'),
                        'Status': item.statusDisplay,
                        'Total': item.total.formattedValue
                    });
                });
                JSONToCSVConvertor(exportData, 'Export', true);
            }


            $scope.items = ['item1', 'item2', 'item3'];

            $scope.open = function (size, parentSelector) {
                var parentElem = angular.element(document.querySelector('.product-admin-page'));//parentSelector ?
                    //angular.element($document.querySelector('.product-admin-page')) : undefined;
                var modalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    ariaLabelledBy: 'modal-title',
                    ariaDescribedBy: 'modal-body',
                    templateUrl: 'myModalContent.html',
                    controller: 'ModalInstanceCtrl',
                    controllerAs: '$scope',
                    size: size,
                    appendTo: parentElem,
                    resolve: {
                        items: function () {
                            return $scope.items;
                        }
                    }
                });

                modalInstance.result.then(function (selectedItem) {
                    $scope.selected = selectedItem;
                }, function () {
                    $log.info('Modal dismissed at: ' + new Date());
                });


            };

            $scope.ok = function () {
                $uibModalInstance.close($scope.selected.item);
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
            };
        }])
    .factory('myAppFactory', function ($http) {
        return {
            getData: function () {
                return $http({
                    method: 'GET',
                    url: '/productAdmin/GetAll'
                });
            }
        }
    });


    angular.module('myApp').controller('ModalDemoCtrl', function ($scope, $uibModal, $log, $document) {
        var $ctrl = this;
        $scope.items = ['item1', 'item2', 'item3'];
      
        $scope.animationsEnabled = true;
      
        $scope.open = function (size, parentSelector) {
          var parentElem = parentSelector ? 
            angular.element($document[0].querySelector('.modal-demo ' + parentSelector)) : undefined;
          var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            controllerAs: '$scope',
            size: size,
            appendTo: parentElem,
            resolve: {
              items: function () {
                return $scope.items;
              }
            }
          });
      
          modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
          }, function () {
            $log.info('Modal dismissed at: ' + new Date());
          });
        };
      
        $scope.openComponentModal = function () {
          var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            component: 'modalComponent',
            resolve: {
              items: function () {
                return $scope.items;
              }
            }
          });
      
          modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
          }, function () {
            $log.info('modal-component dismissed at: ' + new Date());
          });
        };
      
        $scope.openMultipleModals = function () {
          $uibModal.open({
            animation: $scope.animationsEnabled,
            ariaLabelledBy: 'modal-title-bottom',
            ariaDescribedBy: 'modal-body-bottom',
            templateUrl: 'stackedModal.html',
            size: 'sm',
            controller: function($scope) {
              $scope.name = 'bottom';  
            }
          });
      
          $uibModal.open({
            animation: $scope.animationsEnabled,
            ariaLabelledBy: 'modal-title-top',
            ariaDescribedBy: 'modal-body-top',
            templateUrl: 'stackedModal.html',
            size: 'sm',
            controller: function($scope) {
              $scope.name = 'top';  
            }
          });
        };
      
        $scope.toggleAnimation = function () {
          $scope.animationsEnabled = !$scope.animationsEnabled;
        };

        $scope.ok = function () {
            $uibModalInstance.close($scope.selected.item);
          };
        
          $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
          };
    });
      
    // Please note that $uibModalInstance represents a modal window (instance) dependency.
    // It is not the same as the $uibModal service used above.
    
    angular.module('myApp').controller('ModalInstanceCtrl', function ($uibModalInstance, items, $uibModal) {
      var $scope = this;
      $scope.items = items;
      $scope.selected = {
        item: $scope.items[0]
      };
    
      $scope.ok = function () {
        $uibModalInstance.close($scope.selected.item);
      };
    
      $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
      };
    });
      
      