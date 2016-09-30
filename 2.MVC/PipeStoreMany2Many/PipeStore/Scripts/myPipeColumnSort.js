$(document).ready(function () {
    $(".header").click(function (evt) {

        var sortfield = $(evt.target).data("sortfield");
        $("#sortInfo").val(sortfield);
        $("form").submit();

    });
});