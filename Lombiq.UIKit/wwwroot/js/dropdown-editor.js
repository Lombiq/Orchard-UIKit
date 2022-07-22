"use strict";

function removeSelectedFromDropDown(buttonId) {
  // Remove selected item from the dropdown list.
  var button = $('#' + buttonId + '.dropdownEditor__button');
  var buttonItems = button.siblings().children();
  var buttonText = button[0].innerText.trim();
  $.each(buttonItems, function arrangeClasses(index, item) {
    if (buttonText === item.innerText.trim()) {
      item.classList.add('d-none');
    } else {
      item.classList.remove('d-none');
    }
  });
} // It's used from the dropdown shape.

/* eslint-disable no-unused-vars */


function dropdownOnClick(id, buttonId, aspId, removeSelected) {
  return $('#' + id + ' div a').on('click', function dropDownOnClickFunc() {
    var state = $(this).data('state');
    var text = $(this).data('state-text');
    var btnClass = $(this).data('class');
    var lastclass = $('#' + buttonId).attr('class').split(' ').pop();
    $('#' + buttonId).text(text).removeClass(lastclass).addClass(btnClass); // Set hidden input value.

    $('#' + aspId).val(state);

    if (removeSelected) {
      removeSelectedFromDropDown(buttonId);
    }
  });
}
/* eslint-enable no-unused-vars */