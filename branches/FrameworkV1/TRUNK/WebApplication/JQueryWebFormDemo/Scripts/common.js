/// <reference path="jquery-1.4.4-vsdoc.js" />
/// <reference path="jquery.validate.js" />

$(function () {
    /*
    1) Register the the validator when page load
    */

    //$("#mainForm").validate();

    /*
    * 2) Alternativly manually trigger the form validate
    */
    //    $("#btnSubmit").bind("click", function (evt) {
    //        /*
    //        if(!ValidateInput()){
    //        return false;
    //        }*/

    //        var isFormValid = $('#mainForm').validate().form();
    //        if (!isFormValid) {
    //            return false;
    //        }
    //    });

   /* $("#mainForm").validate({
        rules: {
            txtFirstName: {
                required: true
            },
            ctl00$MainContent$txtLastName:{
                required: true
            }
        },
        messages: {
            txtFirstName: {
                required: "first name required"
            },
            ctl00$MainContent$txtLastName:{
                required: "last name required"
            }
        }//,
        //onsubmit: false
    });*/
});

function setupStudentFormValidation() {
    
}
function ValidateInput() {
    var isFormValid = $('#mainForm').validate().form();
    if (isFormValid) {
        return true;
    }

    return false;
}