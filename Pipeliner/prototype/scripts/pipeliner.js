(function ($, window) {

    var idMappingFunction = function (item) {
        return ko.utils.unwrapObservable(item.id);
    }

    var mapping = {
        pipelineDescription: {
            create: function (data) {
                return ko.mapping.fromJS(data.data, {
                    steps: { key: idMappingFunction }
                });
            }
        },
        pipelineInstances: {
            key: idMappingFunction,
            create: function (data) {
                return ko.mapping.fromJS(data.data, {
                    steps: { key: idMappingFunction }
                });
            }
        }
    };

    $(document).ready(function () {
        var model = ko.mapping.fromJS(window.pipelinerData, mapping);
        ko.applyBindings(model);
        
        $(document).on("click", ".pipeline-transition.manual", function (e) {
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

            ko.mapping.fromJS(window.pipelinerData, mapping, model);

            if (i <= 2)
                setTimeout(emulate, 3000);
        }, 3000);
    });
    

})(jQuery, window);

