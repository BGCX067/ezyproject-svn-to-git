/// <reference path="jquery-1.5.1-vsdoc.js" />

var JsonDemo = JsonDemo || {};

JsonDemo.Site = function () {

    $("#GetStudent").bind("click", function (evt) {
        alert("test");
        $.ajax({
            url: "/Json/GetStudents",
            dataType: "json",
            success: function (msg) {
                $("#studenData").val(JSON.stringify(msg));
            }
        }
      )
    });

//    $("#SaveStudent").bind("click", function (evt) {
//        evt.preventDefault(); //prevent default submit

//        var formData = $('form').serialize();

//        alert(formData);
//    });
};

JsonDemo.init = function () {
    JsonDemo.Site();
};

$(function () {
    JsonDemo.init();
});