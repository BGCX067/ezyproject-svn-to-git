/// <reference path="jquery-1.5.1-vsdoc.js" />

var Demo = Demo || {};

Demo.site = function () {
    $('.delete').live('click', function () {
        if (confirm('Are you sure you want to delete this item?')) {
            $.ajax({
                url: this.href,
                type: 'POST',
                success: function (result) {
                    $("#session-list").html(result);
                }
            });

            return false;
        }
        return false;
    });

    $("form.hijax").submit(function (event) {
        if ($("#use_ajax")[0].checked == false)
            return;

        event.preventDefault();  //prevent the actual form post
        hijack(this, update_sessions, "html");
    });

    function hijack(form, callback, format) {
        $("#indicator").show();
        if ($(form).valid()) {
            $.ajax({
                url: form.action,
                type: form.method,
                dataType: format,
                data: $(form).serialize(),
                completed: $("#indicator").hide(),
                success: callback
            });
        }
    }
    function update_sessions(result) {
        //clear the form
        $("form.hijax")[0].reset();

        //update the table with the resulting HTML from the server
        $("#session-list").html(result);
        $("#message").hide().html("session added")
                .fadeIn('slow', function () {
                    var e = this;
                    setTimeout(function () { $(e).fadeOut('slow'); }, 2000);
                });
    }  
};

Demo.general = function () {
    $(".datepicker").datepicker({
        buttonImage: '/Content/Images/calendar.png',
        buttonImageOnly: true,
        dateFormat: 'dd/mm/yy',
        showOn: 'both'
    });

    $("#show").live("click", function () {
        Demo.share.showDialog("test", "#msg", "this is test window");
    });

//    $("#form1").submit(function (evt) {
//        //evt.preventDefault();
//        //alert("test");
//        //Demo.share.showDialog("test", "#msg", "this is test window");
//        Demo.share.confirmDialog("Are you sure you want to delete?", "#delConfirm", "Delete Confirmation");
//        return false;
//    });

//        $("#savePatient").live("click", function () {
//            Demo.share.confirmDialog("Are you sure you want to delete?", "#delConfirm", "Delete Confirmation");
//            return false;
//        });

};

Demo.share = {
    showDialog: function (message, target, title) {
        var $dialog = $(target);
        $dialog.empty();
        $(target).append(message);
        $dialog
		    .dialog({
		        modal: true,
		        title: title,
		        resizable: false,
		        height: 140,
		        buttons: {
		            Ok: function () {
		                $(this).dialog("close");
		            }
		        }
		    });
        $dialog.dialog('open');
    },
    confirmDialog: function (message, target, title) {
        var $dialog = $(target);
        $dialog.empty();
        $(target).append(message);
        $dialog.dialog({
            resizable: false,
            height: 140,
            modal: true,
            title: title,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                    $("#form1").submit();
                    return true;
                },
                Cancel: function () {
                    $(this).dialog("close");
                    return false;
                }
            }
        });
    }
};
Demo.init = function () {
    if ($('form.hijax').length > 0) {
        Demo.site();
    }
    Demo.general();
    //Demo.form1();
    //Demo.share();
};

$(function () {
    Demo.init();
    
});