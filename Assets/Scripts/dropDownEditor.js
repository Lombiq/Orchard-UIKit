function removeSelectedFromDropDown(buttonId) {
    /* Remove selected */

    const button = $('#' + buttonId + '.dropDown__Button');
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

/* eslint-disable no-unused-vars */
/* It's used from the dropDown shape */
function dropdownOnClick(id, buttonId, aspId, removeSelected) {
    return $('#' + id + ' div a').on('click', function dropDownOnClickFunc() {
        const state = $(this).data('state');
        const text = $(this).data('state-text');
        const btnClass = $(this).data('class');
        $('#' + buttonId)
            .text(text)
            .removeClass('btn-warning btn-success btn-danger')
            .addClass(btnClass);

        /* Set hidden input value */
        $('#' + aspId).val(state);

        if (removeSelected) {
            removeSelectedFromDropDown(buttonId);
        }
    });
}
/* eslint-enable no-unused-vars */
