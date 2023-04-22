/**
 * User can check the radio button with large area than just
 * circle or label of the button - the white space between circle and label
 * @param radioHolders get all the block radio__holder that surround radio button and its label
 * @param radioInput get the input element type radio of the block radio__holder
 * @param groupName is the name of the input type radio
 * @param otherRadioInputs get all other input element type radio have the same name
 * Author: LDTUAN (18/04/2023)
 */
function radioBtnClick() {
  const radioHolders = document.querySelectorAll(".radio__holder");
  radioHolders.forEach(function (radioHolder) {
    radioHolder.onclick = function () {
      const radioInput = radioHolder.querySelector(".radio__input");
      /* 
          we can replace all the code blow with: radioInput.checked = true;
          and it still work
          in the following code: we obtain group name to uncheck all the other 
          radio buttons that have the same group name, and we only need to checked
          the radio button that we want.
          the difference is that we can change the group name and interact with the group name we want
          */
      const groupName = radioInput.name;
      const otherRadioInputs = document.querySelectorAll(
        'input[name="' + groupName + '"]'
      );
      if (otherRadioInputs != radioInput) {
        otherRadioInputs.checked = false;
        radioInput.checked = true;
      }
    };
  });
}

