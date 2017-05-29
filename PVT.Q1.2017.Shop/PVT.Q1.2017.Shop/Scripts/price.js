function convertToPriceTextbox(id) {
    convertToNumericTextbox($('#' + id),
        {
            allowFractional: true,
            integerPartMaxLength: 9,
            fractionalPartMaxLength: 2,
            required: true,
            isMoney: true,
            showTooltip: true,
            acceptNegative: false,
            decimalSeparator: ',',
            scriptVersion: 31
        });
}