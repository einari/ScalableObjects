(function () {
    "use strict";

    var viewModel = function () {
        var self = this;

        this.actors = ko.observableArray();

        function getActors() {
            $.getJSON("actors", function (data) {
                self.actors(data);
            });
        }

        this.addSphere = function () {
            $.ajax({
                type: "POST",
                url: "sphere"
            });
        };

        this.addBox = function () {
            $.ajax({
                type: "POST",
                url: "box"
            });
        };

        this.refresh = function () {
            getActors();
        };

        this.delete = function (actor) {
            $.ajax({
                type: "DELETE",
                url: "sphere",
                data: 1
            });
        };


        (function constructor() {
            getActors();
        })();
    };

    $(function () {
        var viewModelInstance = new viewModel();
        ko.applyBindings(viewModelInstance);
    });
})();