app.factory('artists', function ($resource) {
    return $resource(
        "/api/artists/:Id",
        { Id: "@Id" },
        { "update": { method: "PUT" } }
    );
});