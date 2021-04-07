(($) => {
    $(() => {
        /* This part is responsible for the asterisk in the placeholder if needed. */
        $('.textBoxEditor__placeholder').click(function textBoxEditorClick() {
            $(this).siblings('input').focus();
        });

        $('.textBoxEditor__input').blur(function formControlBlur() {
            const $this = $(this);
            if ($this.val().length === 0) {
                $(this).siblings('.textBoxEditor__placeholder').show();
            }
        });

        $('.textBoxEditor__input.textBoxEditor__label_required').on('input', function onInput() {
            if ($(this)[0].value.length === 0) {
                $(this).siblings('.textBoxEditor__placeholder').show();
            }
            else {
                $(this).siblings('.textBoxEditor__placeholder').hide();
            }
        });

        $('.textBoxEditor__input').blur();
    });
})(jQuery);
