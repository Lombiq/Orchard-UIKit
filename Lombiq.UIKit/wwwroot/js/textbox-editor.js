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
