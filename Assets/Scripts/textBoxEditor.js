(($) => {
    $(() => {
        /* This part is responsible for the asterisk in the placeholder if needed. */
        $('.textboxEditor__placeholder').click(function textBoxEditorClick() {
            $(this).siblings('input').focus();
        });

        $('.textboxEditor__input').blur(function formControlBlur() {
            const $this = $(this);
            if ($this.val().length === 0) {
                $(this).siblings('.textboxEditor__placeholder').show();
            }
        });

        $('.textboxEditor__input.textboxEditor__input_required').on('input', function onInput() {
            if ($(this)[0].value.length === 0) {
                $(this).siblings('.textboxEditor__placeholder').show();
            }
            else {
                $(this).siblings('.textboxEditor__placeholder').hide();
            }
        });

        $('.textboxEditor__input').blur();
    });
})(jQuery);
