(($) => {
    $(() => {
        /* This part is responsible for the asterisk in the placeholder if needed. */
        $('.textBoxEditor__placeholder').click(function textBoxEditorClick() {
            $(this).siblings('input').focus();
        });

        $('.form-control').focus(function formControlFocus() {
            $(this).siblings('.textBoxEditor__placeholder').hide();
        });

        $('.form-control').blur(function formControlBlur() {
            const $this = $(this);
            if ($this.val().length === 0) {
                $(this).siblings('').show();
            }
        });

        $('.form-control').blur();
    });
})(jQuery);
