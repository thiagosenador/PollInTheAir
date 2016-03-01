$(function () {
    $('form').each(function () {
        $(this).submit(function () {
            $(this).find('div.form-group').each(function () {
                if ($(this).find('span.field-validation-error').length > 0) {
                    $(this).addClass('has-error');
                    $(this).find('span.field-validation-error').removeClass('field-validation-error');
                }
            });
        });
    });
});