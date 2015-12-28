/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="jquery.form.js" />


var Demo = Demo || {};


Demo.form1 = function () {
    $("#test").bind("click", function (evt) {
        alert("test");
    });



    SubmitMyForm() = function () {
        var options = {
            target: '#divResults',
            beforeSubmit: validateInput,
            success: addSuccess,
            error: failureAlert,
            resetForm: true
        };

        function addSuccess(responseText) {
            alert(responseText);
        }
        function failureAlert(xhr) {
            if (xhr.status == 400) {
                $("#divResults").html(xhr.responseText, xhr.status);
            }
        }
        $('#myform').ajaxForm(options);
    };

    function validateInput() {
        if ($("#FirstName").val() == "") {
            alert("please enter first name");
            $("#FirstName").focus();
            return false;
        }
    }
};



$(function () {
    //alert("test");
    Demo.form1();
    
    //SubmitMyForm();

});