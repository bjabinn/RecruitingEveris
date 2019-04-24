//Array with the scripts js
var callbacks = new Array();
var callbacksLast = new Array();

function registerCallback(callbackFunction, isLast) {
    if (isLast == true ) {
        callbacksLast.push(callbackFunction);
    } else {
        callbacks.push(callbackFunction);
    }
}

function runCallbacks() {
    for (var i = 0; i < callbacks.length; i++) {
        callbacks[i]();
    }

    for (var i = 0; i < callbacksLast.length; i++) {
        callbacksLast[i]();
    }
}

function bindComponents(container) {
    if (container == null) {
        container = $('body');
    }

    container.find('[data-a-dec], [data-a-sep], [data-v-min], [data-v-max], [data-m-dec]').autoNumeric('init');

    container.find('.datepicker').datepicker(
        {
        firstDay: 1,
        selectOtherMonths: true,
        changeMonth: true,
        changeYear: true
    });

    container.find('[data-type="text-editor"]').summernote(
    {
        tabsize: 2,
        height: 100,
        });

    container.find('#datetimepicker input').datetimepicker(
        {
            firstDay: 1,
            timeFormat: "HH:mm",
            locale: 'es'          
        });

}

function bindGenericHandler() {

    //Collapsible Handler
    // data-collapse="[data-id=formFilter]" data-collapse-time="200"
    $(document).on("click", "[data-collapse]", function (e) {
        e.preventDefault();
        var source = $(e.currentTarget);
        var showText = source.attr("data-collapse-show-text");
        var hideText = source.attr("data-collapse-hide-text");
        var collapsibleRegionSelector = source.attr("data-collapse");
        var timeToCollapse = parseInt(source.attr("data-collapse-time"));

        if (isNaN(parseInt(timeToCollapse))) {
            timeToCollapse = 200;
        }
        if (showText == null) {
            showText = "Mostrar";
        }
        if (hideText == null) {
            hideText = "Ocultar";
        }

        var collapsibleRegion = $(collapsibleRegionSelector);
        var isCollapsed = collapsibleRegion.attr("data-collapse-is-collapsed") === "true";

        if (isCollapsed) {
            collapsibleRegion.slideDown(timeToCollapse);
            source.html(hideText);
            collapsibleRegion.attr("data-collapse-is-collapsed", "false");
        } else {
            collapsibleRegion.slideUp(timeToCollapse);
            source.html(showText);
            collapsibleRegion.attr("data-collapse-is-collapsed", "true");
        }
    });

    $(document).on("click", "[data-action]", function (e) {
        e.preventDefault();
        var source = $(e.currentTarget);
        var actionToExcecute = source.attr("data-action");

        var func = window[actionToExcecute];
        if ((func != null) && (typeof func === "function")) {
            func(source);
        }
    });
}

function initParsley(container) {
    if (container == null) {
        container = $('form[data-parsley-validate]');
    }

    container.parsley(
    {
        errorsContainer: function (parsleyField) {
            var field = parsleyField.$element;
            var tagName = field[0].tagName;
            if (tagName == "INPUT") {
                if (field.attr("type") == "radio") {
                    return field.parent().parent();
                }
            }
        },
    });
}

function GetFilterForSearchableTable(originalFilter) {

    var filterToUpload = {};
    for (var name in originalFilter) {
        var newName = "custom-filter-" + name;
        var value = originalFilter[name];
        filterToUpload[newName] = value;
    }
    return filterToUpload;
}

window.ParsleyConfig = window.ParsleyConfig || {}
$.extend(window.ParsleyConfig, {
    excluded:
        '[data-searchable-input="text"]'  // Exclude all nesting inputs/selects/radios/checkboxes/etc
});