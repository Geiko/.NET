'use strict';
$(document).ready(function () {
    (function () {
        $('#FilterType, #SortType').change(function () {
            $('#filterForm').submit();
        });
    })();
});