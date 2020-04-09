var app = angular.module("fgcm", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/",
            {
                templateUrl: "/app/views/album.html"
            })
        .when("/photo/:id",
            {
                templateUrl: "/app/views/photo.html"
            })
        .when("/post/:id",
            {
                templateUrl: "/app/views/post.html"
            })
        .otherwise({ redirectTo: "/" });
});


app.controller("photoController",
    function (fgcmService, $routeParams, $location) {
        var vm = this;

        vm.init = function() {

            fgcmService.getAll().then(function (data) {

                var currentData = data.data.photos.filter(function(item) {

                    return item.albumId === parseInt($routeParams.id);
                });

                vm.data = currentData;
            });
        };

        vm.rowSelected = function (item) {

            $location.path("/post/" + item.id);
        };
    });

app.controller("albumController",
    function (fgcmService, $routeParams, $location) {
        var vm = this;


        vm.init = function () {

            fgcmService.getAll().then(function (data) {

                vm.data = data.data.albums;
            });
        };

        vm.rowSelected = function (item) {

            $location.path("/photo/" + item.id);
        };
    });

app.controller("postController",
    function (fgcmService, $routeParams) {
        var vm = this;

        vm.init = function () {

            fgcmService.getAll().then(function (data) {

                var currentData = data.data.post.filter(function (item) {

                    return item.postId === parseInt($routeParams.id);
                });

                vm.data = currentData;
            });
        };
    });

app.service("fgcmService", function ($http) {

    var self = this;

    self.getAll = function () {

        return $http.get("/home/getResources");

    };

    return self;

});