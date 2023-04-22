/**
 * Display or hide popup when user click to view or exit button
 * @param buttonView get the button view to open popup
 * @param popup get the block popup to interact with
 * Author: LDTUAN (18/04/2023)
 */
const employeeInputs = document.querySelectorAll(
  ".body__input-control .input-control__input .input__holder"
);
function displayPopup() {
  const buttonView = document.querySelector(".popup__button .button__view");
  const popup = document.querySelector(".popup");
  buttonView.onclick = function () {
    popup.style.visibility = "visible";
    employeeInputs[0].value = "NV001";
    employeeInputs[0].focus();
  };
  iconExitClick(popup);
}
