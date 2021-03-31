function dropdownOnClick(id, buttonId, aspId) {
    return $('#' + id + ' div a').on('click', function () {
        var state = $(this).data('state');
        var text = $(this).data('state-text');
        var btnClass = $(this).data('class');
        $('#' + buttonId)
            .text(text)
            .removeClass('btn-warning btn-success btn-danger')
            .addClass(btnClass);

        //Set hidden input value
        $('#' + aspId).val(state);

        removeSelectedFromDropDown(buttonId);
    });
};

function removeSelectedFromDropDown(buttonId) {
    //Remove selected 
    var button = $("#" + buttonId + ".dropDown__Button");
    var buttonItems = button.siblings().children();
    var buttonText = button[0].innerText.trim();

    $.each(buttonItems, function (index, item) {
        if (buttonText == item.innerText.trim()) {
            item.classList.add("d-none");
        }
        else {
            item.classList.remove("d-none");
        };
    });
};

// This part is responsible for the asterisk in the placeholder if needed.
(function ($) {
    $(function () {
        $('.textBoxEditor__placeholder').click(function () {
            $(this).siblings('input').focus();
        });

        $('.form-control').focus(function () {
            $(this).siblings('.textBoxEditor__placeholder').hide();
        });

        $('.form-control').blur(function () {
            var $this = $(this);
            if ($this.val().length == 0)
                $(this).siblings('').show();
        });

        $('.form-control').blur();
    });
})(jQuery);
