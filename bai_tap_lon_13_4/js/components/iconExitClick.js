/**
 * Common function to close the form when the user clicks icon exit
 * @param {*} formGroup get the form with which the user is interacting
 * Author: LDTUAN (19/04/2023)
 */
function iconExitClick(formGroup) {
  const iconExit = formGroup.querySelector(".icon-exit");
  iconExit.addEventListener("click", function () {
    formGroup.style.visibility = "hidden";
  });
}
