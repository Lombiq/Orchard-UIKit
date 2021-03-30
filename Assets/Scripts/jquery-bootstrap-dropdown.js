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
    });
};


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
