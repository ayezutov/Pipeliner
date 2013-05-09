(function ($, window) {
    $(document).ready(function () {
        var model = ko.mapping.fromJS(window.pipelinerData);
        ko.applyBindings(model);
        
        $(".pipeline-transition.manual").click(function (e) {
            alert("Clicked!");
        });
        
        var i = 0;
        setTimeout(function emulate() {
            var data = window.pipelinerData;

            var steps = data.pipelineInstances[0].steps;

            steps[i].status = 'success';
            steps[i].transition.status = i <= 1 ? "success" : "manual";

            if (i < 2) {
                steps[i + 1].status = "running";
            }

            i++;

            ko.mapping.fromJS(window.pipelinerData, model);

            if (i <= 2)
                setTimeout(emulate, 3000);
        }, 3000);
    });
    

})(jQuery, window);

