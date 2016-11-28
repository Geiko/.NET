'use strict';
$(document).ready(function () {
    $('#export').click(function () {

        $('#isExport').val('true');
        $('#filterForm').submit();
        $('#isExport').val('false');
    });
});