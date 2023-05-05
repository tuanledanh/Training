/**
 * Capture the event when the user clicks on a button, if having some errors then
 * Dialog display
 * @param btnSave is the button store and save
 * Author: LDTUAN (19/04/2023)
 */
function btnSaveOnClick() {
  const btnSave = document.getElementById("btnSave");
  btnSave.onclick = function () {
    const errors = validateData();
    if (errors.length > 0) {
      showErrors(errors);
    }
  };
}

/**
 * Validate the data from the popup when the user clicks the button store and save
 * @param errors contain the list errors
 * @param inputRequires get all the input that have required attribute
 * @param value is the value of the input
 * @param label is the field label attribute of the input field
 * @param inputControl is the closet parent element of the input
 * @param oldNotice is the element to notice user if the input is empty
 * @param notice is the new element that appends into inputControl if input is empty
 * @returns list of errors
 * Author: LDTUAN (19/04/2023)
 */
function validateData() {
    var errors = [];
    // Kiểm tra các dữ liệu bắt buộc nhập
    let inputRequires = document.querySelectorAll("[required]");
    for (const input of inputRequires) {
      const value = input.value;
      const label = input.getAttribute("field-label");
      let inputControl = input.closest(".body__input-control");
      let oldNotice = inputControl.querySelector(".input-control__notice");
      
      if (value.trim() == "") {
        // Đổi màu border nếu input field trống
        input.parentElement.classList.add("required");
        errors.push(`${label} không được phép để trống`);
  
        // Thêm dòng chữ không được bỏ trống với input filed trống
        if (oldNotice == null) {
          const notice = document.createElement("div");
          notice.className = "input-control__notice";
          notice.textContent = `${label} không được để trống`;
          inputControl.appendChild(notice);
        }
      }
      else {
        if (oldNotice != null) {
          inputControl.removeChild(oldNotice);
        }
        input.parentElement.classList.remove("required");
      }
    }
    // Kiểm tra các dữ liệu cần đúng định dạng (VD email)
  
    // Kiểm tra các dữ liều ngày tháng (VD ngày sinh không được lớn hơn ngày hiện tại)
  
    // Kiểm tra độ dài của các chuỗi có giới hạn số lượng ký tự (VD nghiệp vụ yêu cầu mã nhân viên không được lớn hơn 20 ký tự)
  
    return errors;
  }
  
/**
 * Show all the errors in dialog
 * @param {*} errors the list errors when the user doesn't fill all the input fields
 * @param dialog get the dialog to display
 * @param dialogContent get the contents of dialog to change
 * Author: LDTUAN (19/04/2023)
 */
function showErrors(errors) {
  const dialog = document.getElementById("dialog-notice");
  dialog.style.visibility = "visible";
  const dialogContent = dialog.querySelector(
    ".dialog-wrapper .dialog__content"
  );
  // Xóa content cũ
  dialogContent.innerHTML = "";
  let divIconHtml = document.createElement("div");
  divIconHtml.classList.add("dialog-content__icon");
  divIconHtml.classList.add("icon--warning");
  dialogContent.append(divIconHtml);
  let divMessHtml = document.createElement("div");
  divMessHtml.classList.add("dialog-content__message");
  // Thay content mới
  for (const error of errors) {
    // Cú pháp tạo 1 HTML Element
    let liHTML = document.createElement("li");
    liHTML.innerText = error;
    divMessHtml.append(liHTML);
    dialogContent.append(divMessHtml);
  }
}
