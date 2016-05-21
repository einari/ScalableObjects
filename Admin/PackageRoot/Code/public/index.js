(function () {
    var viewModel = function () {
        var self = this;

        this.counter = ko.observable(0);

        setInterval(function () {
            self.counter(self.counter() + 1);
        }, 1000);
    };

    $(function () {
        var viewModelInstance = new viewModel();
        ko.applyBindings(viewModelInstance);
    });
})();