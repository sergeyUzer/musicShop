$(document).ready(function () {
    $(".delete-link").click(function () {
        alert("!");
        $(this).closest("form")[0].submit();
    });
});