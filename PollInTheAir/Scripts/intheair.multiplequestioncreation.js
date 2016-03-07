﻿$(function () {
    $(document).on('click', '.btn-add', function (e) {
        e.preventDefault();

        var controlForm = $('.controls'),
            currentEntry = $(this).parents('.entry:first'),
            newEntry = $(currentEntry.clone()).appendTo(controlForm);

        newEntry.find('input').val('');

        $("[id=choiceField]").each(function (i) {
            var newId = 'Choices[' + i + '].Text'
            $(this).attr('name', newId);
        });

        controlForm.find('.entry:not(:last) .btn-add')
            .removeClass('btn-add')
            .addClass('btn-remove')
            .removeClass('btn-primary')
            .addClass('btn-warning')
            .html('<span class="glyphicon glyphicon-minus"></span>');
    }).on('click', '.btn-remove',
        function (e) {
            $(this).parents('.entry:first').remove();
            e.preventDefault();

            $("[id=choiceField]").each(function (i) {
                $(this).attr('name', 'Choices[' + i + '].Text');
            });

            return false;
        });
});