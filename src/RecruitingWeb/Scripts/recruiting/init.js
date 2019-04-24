$(document).ready(function () {
    bindComponents();
    loadRunCallbacks();
    runCallbacks();
    initParsley();
    bindGenericHandler();


    $('input[data-type="checkBoxDig"]').click(function (e) {
        var element = $(this);

        if (element.prop("checked")) {
            element.val("True");
        }
        else {
            element.val("False");
        }
    });

    $(document).on('change', 'input[data-type="file-upload"]', function () {
        var fileUpload = $(this);
        var fileComponent = fileUpload.closest('div[data-type="file-component"]');
        var fileName = fileComponent.find('[data-type="file-name"]');
        var fileValue = fileUpload.val();
        var fileValueFilterName = fileValue.replace("C:\\fakepath\\", "");
        fileName.val(fileValueFilterName);
    });


    $(document).on('click', 'button[data-type="file-browse"]', function () {
        var fileBrowse = $(this);
        var fileComponent = fileBrowse.closest('div[data-type="file-component"]');
        var fileUpload = fileComponent.find('[data-type="file-upload"]');
        fileUpload.click();
    });

});