$(function () {
    $.validator.methods.date = function (value, element) {
        return this.optional(element) || moment(value, "DD.MM.YYYY", true).isValid();
    }

    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    }

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    }

    var date = new Date();
    date.setDate(date.getDate());
    $(".datecontrol").datepicker({
        startDate: date,
        dateFormat: 'dd.mm.yy',
        autoclose: true,
        todayHighlight: true,
        weekStart: 1,
        language: 'de-DE',
        calendarWeeks: true
    });
});