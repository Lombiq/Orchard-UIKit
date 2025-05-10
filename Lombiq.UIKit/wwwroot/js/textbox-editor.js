document.querySelectorAll('.textboxEditor__placeholder').forEach((item) => item
    .addEventListener('click', () => item
        .parentElement.querySelector('.textboxEditor__input').focus()));

function hidePlaceholder(item) {
    const placeholder = item.parentElement.querySelector('.textboxEditor__placeholder');
    if (placeholder) placeholder.hidden = item.value?.toString().trim();
}

document.querySelectorAll('.textboxEditor__input').forEach((item) => {
    item.addEventListener('blur', () => hidePlaceholder(item));
    hidePlaceholder(item);

    if (item.classList.contains('textboxEditor__input_required')) {
        item.addEventListener('input', () => hidePlaceholder(item));
    }
});
