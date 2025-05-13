// Focus on the textbox after clicking on the icon on the left.
document.querySelectorAll('.input-group-prepend:has(.textboxEditor__iconContainer)').forEach((item) => item
    .addEventListener('click', () => item.parentElement.querySelector('.textboxEditor__input').focus()));

// Hide custom placeholder when there is text in the textbox.
document.querySelectorAll('.textboxEditor__input').forEach((item) => {
    const placeholder = item.parentElement.querySelector('.textboxEditor__placeholder');
    if (!placeholder) return;

    function hideIfInputHasContent() {
        placeholder.hidden = item.value?.toString().trim();
    }

    ['blur', 'keyup', 'change'].forEach((eventName) => item
        .addEventListener(eventName, hideIfInputHasContent));

    hideIfInputHasContent();
});
