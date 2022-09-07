function removeSelectedFromDropDown(buttonId) {
    // Remove selected item from the dropdown list.

    const button = $('#' + buttonId + '.dropdownEditor__button');
    const buttonItems = button.siblings().children();
    const buttonText = button[0].innerText.trim();

    $.each(buttonItems, function arrangeClasses(index, item) {
        if (buttonText === item.innerText.trim()) {
            item.classList.add('d-none');
        }
        else {
            item.classList.remove('d-none');
        }
    });
}

// It's used from the dropdown shape.
/* eslint-disable no-unused-vars */
function dropdownOnClick(id, buttonId, aspId, removeSelected) {
    return $('#' + id + ' ul li a').on('click', function dropDownOnClickFunc() {
        const state = $(this).data('state');
        const text = $(this).data('state-text');
        const btnClass = $(this).data('class');
        const btnStyle = $('#' + buttonId).attr('class').split(' ').at(-2);

        $('#' + buttonId)
            .text(text)
            .removeClass(btnStyle)
            .addClass(btnClass);

        // Set hidden input value.
        $('#' + aspId).val(state);

        if (removeSelected) {
            removeSelectedFromDropDown(buttonId);
        }
    });
}
/* eslint-enable no-unused-vars */
