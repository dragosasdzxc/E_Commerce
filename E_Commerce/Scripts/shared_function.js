
/**
 * [Convert all special characters of Vietnamese alphabet to common characters of English alphabet]
 * @param {string} string The input string contain special character in Vietnamese alphabet
 * @returns {string} Return a string all contain common character in English alphabet
 */
function convertChar(string) {
    string = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    string = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    string = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    string = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    string = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    string = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    string = str.replace(/đ/g, "d");
    string = str.replace(/À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ/g, "A");
    string = str.replace(/È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ/g, "E");
    string = str.replace(/Ì|Í|Ị|Ỉ|Ĩ/g, "I");
    string = str.replace(/Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ/g, "O");
    string = str.replace(/Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ/g, "U");
    string = str.replace(/Ỳ|Ý|Ỵ|Ỷ|Ỹ/g, "Y");
    string = str.replace(/Đ/g, "D");
    string = str.replace(/ +/g, " ");

    return string;
}

// Restricts input for each element in the set of matched elements to the given inputFilter.
(function ($) {
    $.fn.inputFilter = function (inputFilter) {
        return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
            if (inputFilter(this.value)) {
                this.oldValue = this.value;
                this.oldSelectionStart = this.selectionStart;
                this.oldSelectionEnd = this.selectionEnd;
            } else if (this.hasOwnProperty("oldValue")) {
                this.value = this.oldValue;
                this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
            } else {
                this.value = "";
            }
        });
    };
}(jQuery));

$(".number").inputFilter(function (value) {
    return /^-?\d*$/.test(value);
});
$(".negative-number").inputFilter(function (value) {
    return /^\d*$/.test(value);
});
$(".limit-number").inputFilter(function (value) {
    $(".limit-number").removeAttr("minlength");
    $(".limit-number").removeAttr("maxlength");
    let min = $(".limit-number").attr("min");
    let max = $(".limit-number").attr("max");
    if (min == null || max == null || min == "" || max == "" || min === "undefined" || max === "undefined") {
        return /-?\d*$/.test(value) && (value === "" || parseInt(value) >= 0 && parseInt(value) <= 2147483647);
    } else {
        return /-?\d*$/.test(value) && (value === "" || parseInt(value) >= min && parseInt(value) <= max);
    }
});
$(".float").inputFilter(function (value) {
    return /^-?\d*[.,]?\d*$/.test(value);
});
$(".currency").inputFilter(function (value) {
    return /^-?\d*[.,]?\d{0,2}$/.test(value);
});
$(".latin-text").inputFilter(function (value) {
    return /^[a-z]*$/i.test(value);
});
$(".hex-text").inputFilter(function (value) {
    return /^[0-9a-f]*$/i.test(value);
});


