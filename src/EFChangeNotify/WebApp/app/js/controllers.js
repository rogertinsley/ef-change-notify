app.controller('ArtistsCtrl', function ($scope, hubProxy, artists) {
    $scope.artistsData = artists.query();
    $scope.gridOptions = {
        data: 'artistsData',
        columnDefs: [{ field: 'ArtistId', displayName: 'ID' }, { field: 'Name', displayName: 'Name' }]
    };

    var hub = hubProxy(hubProxy.defaultServer, 'notificationHub');
    hub.start();
    hub.on('refresh', function () {
        $scope.artistsData = artists.query();
    });
});