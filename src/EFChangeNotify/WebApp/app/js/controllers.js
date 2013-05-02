app.controller('ArtistsCtrl', function ($scope, signalRHubProxy, artists) {
    $scope.artistsData = artists.query();
    $scope.gridOptions = {
        data: 'artistsData',
        columnDefs: [{ field: 'ArtistId', displayName: 'ID' }, { field: 'Name', displayName: 'Name' }]
    };

    var dataHub = signalRHubProxy(signalRHubProxy.defaultServer, 'notificationHub');
    dataHub.on('refresh', function (data) {
        $scope.artistsData = artists.query();
    });
});