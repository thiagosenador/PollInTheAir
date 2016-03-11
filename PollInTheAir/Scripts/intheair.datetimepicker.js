// DATETIME PICKER

$(function () {
    var locale = window.navigator.userLanguage || window.navigator.language;

    $('#ExpirationDate').datetimepicker({
        minDate: moment().add(1, 'hour'),
        maxDate: moment().add(1, 'month'),
        locale: moment.locale(locale),
        showClose: true
    });

    $("#datepickerIcon").click(function () {
        $('#ExpirationDate').data('DateTimePicker').show();
    });
});