// Focus on the textbox after clicking on the icon on the left.
document.querySelectorAll('.input-group-prepend:has(.textboxEditor__iconContainer)').forEach((item) => item
    .addEventListener('click', () => item.parentElement.querySelector('.textboxEditor__input').focus()))

// Hide custom placeholder when there is text in the textbox.
document.querySelectorAll('.textboxEditor__input').forEach((item) => {
    function hidePlaceholder(item, placeholder) {
        placeholder.hidden = item.value?.toString().trim();
    }

    const placeholder = item.parentElement.querySelector('.textboxEditor__placeholder');
    if (!placeholder) return;

    ['blur', 'keyup', 'change'].forEach((eventName) => item
        .addEventListener(eventName, () => hidePlaceholder(item, placeholder)));

    hidePlaceholder(item, placeholder);
});
